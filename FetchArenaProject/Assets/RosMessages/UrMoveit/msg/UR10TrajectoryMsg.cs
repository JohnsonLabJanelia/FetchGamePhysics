//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.UrMoveit
{
    [Serializable]
    public class UR10TrajectoryMsg : Message
    {
        public const string k_RosMessageName = "ur_moveit/UR10Trajectory";
        public override string RosMessageName => k_RosMessageName;

        public Moveit.RobotTrajectoryMsg[] trajectory;

        public UR10TrajectoryMsg()
        {
            this.trajectory = new Moveit.RobotTrajectoryMsg[0];
        }

        public UR10TrajectoryMsg(Moveit.RobotTrajectoryMsg[] trajectory)
        {
            this.trajectory = trajectory;
        }

        public static UR10TrajectoryMsg Deserialize(MessageDeserializer deserializer) => new UR10TrajectoryMsg(deserializer);

        private UR10TrajectoryMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.trajectory, Moveit.RobotTrajectoryMsg.Deserialize, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.WriteLength(this.trajectory);
            serializer.Write(this.trajectory);
        }

        public override string ToString()
        {
            return "UR10TrajectoryMsg: " +
            "\ntrajectory: " + System.String.Join(", ", trajectory.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}