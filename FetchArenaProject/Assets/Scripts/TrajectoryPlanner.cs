using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using RosMessageTypes.Geometry;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;
using RosMessageTypes.UrMoveit;


public class TrajectoryPlanner : MonoBehaviour
{
    // Hardcoded variables
    const int k_NumRobotJoints = 6;
    const float k_JointAssignmentWait = 0.1f;
    const float k_PoseAssignmentWait = 0.5f;

    // Variables required for ROS communication
    [SerializeField]
    string m_RosServiceName = "ur_moveit";
    public string RosServiceName { get => m_RosServiceName; set => m_RosServiceName = value; }

    [SerializeField]
    GameObject m_UrOne;
    public GameObject UrOne { get => m_UrOne; set => m_UrOne = value; }
    [SerializeField]
    GameObject m_Target;
    public GameObject Target { get => m_Target; set => m_Target = value; }
    [SerializeField]
    GameObject m_TargetPlacement;
    public GameObject TargetPlacement { get => m_TargetPlacement; set => m_TargetPlacement = value; }

    // Multipliers correspond to the URDF mimic tag for each joint
    private float[] multipliers = new float[] { -1f, -1f, -1f, 1f, 1f, 1f };

    // Assures that the gripper is always positioned above the m_Target cube before grasping.
    readonly Quaternion m_PickOrientation = Quaternion.Euler(90, 90, 0);
    readonly Vector3 m_PickPoseOffset = Vector3.up * 0.1f;
    readonly float gripperAngle = 14f;
    // Articulation Bodies
    ArticulationBody[] m_JointArticulationBodies;
    //ArticulationBody[] articulationChain;
    private List<ArticulationBody> gripperJoints;

    // ROS Connector
    ROSConnection m_Ros;

    /// <summary>
    ///     Find all robot joints in Awake() and add them to the jointArticulationBodies array.
    ///     Find left and right finger joints and assign them to their respective articulation body objects.
    /// </summary>
    void Start()
    {
        // Get ROS connection static instance
        m_Ros = ROSConnection.GetOrCreateInstance();
        m_Ros.RegisterRosService<MoverServiceRequest, MoverServiceResponse>(m_RosServiceName);


        m_JointArticulationBodies = new ArticulationBody[k_NumRobotJoints];
        
        string shoulder_link = "world/base_link/shoulder_link";
        m_JointArticulationBodies[0] = m_UrOne.transform.Find(shoulder_link).GetComponent<ArticulationBody>();

        string arm_link = shoulder_link + "/upper_arm_link";
        m_JointArticulationBodies[1] = m_UrOne.transform.Find(arm_link).GetComponent<ArticulationBody>();

        string elbow_link = arm_link + "/forearm_link";
        m_JointArticulationBodies[2] = m_UrOne.transform.Find(elbow_link).GetComponent<ArticulationBody>();

        string forearm_link = elbow_link + "/wrist_1_link";
        m_JointArticulationBodies[3] = m_UrOne.transform.Find(forearm_link).GetComponent<ArticulationBody>();

        string wrist_link = forearm_link + "/wrist_2_link";
        m_JointArticulationBodies[4] = m_UrOne.transform.Find(wrist_link).GetComponent<ArticulationBody>();

        string hand_link = wrist_link + "/wrist_3_link";
        m_JointArticulationBodies[5] = m_UrOne.transform.Find(hand_link).GetComponent<ArticulationBody>();

        //Debug.Log("find joints: ", m_JointArticulationBodies[0]);
        // this command doesn't work, don't understand what's this for. it is in the PoseEstimation Tutorial
        //articulationChain = m_UrOne.GetComponent<RosSharp.Control.Controller>().GetComponentsInChildren<ArticulationBody>();

        var gripperJointNames = new string[] { "right_outer_knuckle", "right_inner_finger", "right_inner_knuckle", "left_outer_knuckle", "left_inner_finger", "left_inner_knuckle" };
        gripperJoints = new List<ArticulationBody>();

        foreach (ArticulationBody articulationBody in m_UrOne.GetComponentsInChildren<ArticulationBody>())
        {
            if (gripperJointNames.Contains(articulationBody.name))
            {
                gripperJoints.Add(articulationBody);
            }
        }
    }

    /// <summary>
    ///     Opens and closes the attached gripper tool based on a gripping angle.
    /// </summary>
    /// <param name="toClose"></param>
    /// <returns></returns>
    public IEnumerator IterateToGrip(bool toClose)
    {
        var grippingAngle = toClose ? gripperAngle : 0f;
        for (int i = 0; i < gripperJoints.Count; i++)
        {
            var curXDrive = gripperJoints[i].xDrive;
            curXDrive.target = multipliers[i] * grippingAngle;
            gripperJoints[i].xDrive = curXDrive;
        }
        yield return new WaitForSeconds(k_JointAssignmentWait);
    }


    /// <summary>
    ///     Get the current values of the robot's joint angles.
    /// </summary>
    /// <returns>UrMoveitJoints</returns>
    UR10MoveitJointsMsg CurrentJointConfig()
    {
        var joints = new UR10MoveitJointsMsg();
        for (var i = 0; i < k_NumRobotJoints; i++)
        {
            joints.joints[i] = m_JointArticulationBodies[i].jointPosition[0];
        }

        return joints;
    }

    /// <summary>
    ///     Create a new MoverServiceRequest with the current values of the robot's joint angles,
    ///     the target cube's current position and rotation, and the targetPlacement position and rotation.
    ///     Call the MoverService using the ROSConnection and if a trajectory is successfully planned,
    ///     execute the trajectories in a coroutine.
    /// </summary>
    public void PublishJoints()
    {
        var request = new MoverServiceRequest();
        request.joints_input = CurrentJointConfig();

        // Pick Pose
        request.pick_pose = new PoseMsg
        {
            position = (m_Target.transform.position + m_PickPoseOffset).To<FLU>(),

            // The hardcoded x/z angles assure that the gripper is always positioned above the target cube before grasping.
            orientation = Quaternion.Euler(90, m_Target.transform.eulerAngles.y, 0).To<FLU>()
        };

        // Place Pose
        request.place_pose = new PoseMsg
        {
            position = (m_TargetPlacement.transform.position + m_PickPoseOffset).To<FLU>(),
            orientation = m_PickOrientation.To<FLU>()
        };

        m_Ros.SendServiceMessage<MoverServiceResponse>(m_RosServiceName, request, TrajectoryResponse);
    }

    void TrajectoryResponse(MoverServiceResponse response)
    {
        if (response.trajectories.Length > 0)
        {
            Debug.Log("Trajectory returned.");
            StartCoroutine(ExecuteTrajectories(response));
        }
        else
        {
            Debug.LogError("No trajectory returned from MoverService.");
        }
    }

    /// <summary>
    ///     Execute the returned trajectories from the MoverService.
    ///     The expectation is that the MoverService will return four trajectory plans,
    ///     PreGrasp, Grasp, PickUp, and Place,
    ///     where each plan is an array of robot poses. A robot pose is the joint angle values
    ///     of the six robot joints.
    ///     Executing a single trajectory will iterate through every robot pose in the array while updating the
    ///     joint values on the robot.
    /// </summary>
    /// <param name="response"> MoverServiceResponse received from ur_moveit mover service running in ROS</param>
    /// <returns></returns>
    IEnumerator ExecuteTrajectories(MoverServiceResponse response)
    {
        if (response.trajectories != null)
        {
            // For every trajectory plan returned
            for (var poseIndex = 0; poseIndex < response.trajectories.Length; poseIndex++)
            {
                // For every robot pose in trajectory plan
                foreach (var t in response.trajectories[poseIndex].joint_trajectory.points)
                {
                    var jointPositions = t.positions;
                    var result = jointPositions.Select(r => (float)r * Mathf.Rad2Deg).ToArray();

                    // Set the joint values for every joint
                    for (var joint = 0; joint < m_JointArticulationBodies.Length; joint++)
                    {
                        var joint1XDrive = m_JointArticulationBodies[joint].xDrive;
                        joint1XDrive.target = result[joint];
                        m_JointArticulationBodies[joint].xDrive = joint1XDrive;
                    }

                    // Wait for robot to achieve pose for all joint assignments
                    yield return new WaitForSeconds(k_JointAssignmentWait);
                }

                // Close the gripper if completed executing the trajectory for the Grasp pose
                if (poseIndex == (int)Poses.Grasp)
                {
                    StartCoroutine(IterateToGrip(true));
                    yield return new WaitForSeconds(k_JointAssignmentWait);
                }
                // Wait for the robot to achieve the final pose from joint assignment
                yield return new WaitForSeconds(k_PoseAssignmentWait);
            }

            // All trajectories have been executed, open the gripper to place the target cube
            {
                yield return new WaitForSeconds(k_PoseAssignmentWait);
                // Open the gripper to place the target cube
                StartCoroutine(IterateToGrip(false));
            }
        }
    }

    enum Poses
    {
        PreGrasp,
        Grasp,
        PickUp,
        Place
    }
}
