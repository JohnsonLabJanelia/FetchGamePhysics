# FetchGamePhysics

**Experimenter View**
![three_robots](images/image_exp_view.png)

**Ceiling Camera**
![three_robots](images/ceiling_view.png)


This repo is a **Work In Progress** ditigal twin of our experiment rig. 

Many parts are adapted from [Unity-Robotics-Hub](https://github.com/Unity-Technologies/Unity-Robotics-Hub), especially the [Pick-and-Place Tutorial](https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/README.md) and [Object Pose Estimation Tutorial](https://github.com/Unity-Technologies/Robotics-Object-Pose-Estimation). A basic familiarity on these two tutorials and [ROS Tutorial](http://wiki.ros.org/ROS/Tutorials) would help better working with FetchGamePhysics.  

---
Table of contents
  - [Part 1: Installation Instruction](#part-1-installation-instruction)
  - [Part 2: ROS–Unity Integration](#part-2-rosunity-integration)
  - [Part 3: Pick-and-Place In Unity](#part-3-pick-and-place-in-unity)
---

Note, skip Part 2 and Part 3 if you are only interested in Reinforcement learning agent training with this environment. 

## [Part 1: Installation Instruction](1_installation_instruction.md)

<img src="images/package_manager.png" width="400"/>




## [Part 2: ROS–Unity Integration](2_ros_unity_integration.md)
<img src="images/RosUnityIntegration.png " width="400"/>



## [Part 3: Pick-and-Place In Unity](3_pick_and_place.md)
<img src="images/pick_and_place.gif " width="400"/>


## TODO
- [x] Trajectory planner for picking up the cube and place it on the goal.
- [x] Integrate three robots, working tables, ramp to complete the scene.
- [x] Integration with ur_rtde and UR offline simulator. 
- [ ] Calibration and integration with real robot.
- [ ] Game release 

## Acknowledgement
- Jinyao Yan 
- Philip Hubbard
- David Schauder 
- Jeff Talbot 
- Jon Arnold 
- Rob Johnson 
