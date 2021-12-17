# FetchGamePhysics

![pick_place](https://github.com/JohnsonLabJanelia/FetchGamePhysics/blob/main/images/pick_and_place.gif)



## Getting Started 
This repo is built upon [FetchGame](https://github.com/JohnsonLabJanelia/FetchGame). Many inspirations are taken from [Unity-Robotics-Hub](https://github.com/Unity-Technologies/Unity-Robotics-Hub), especially the [Pick-and-Place Tutorial](https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/README.md) and [Object Pose Estimation Tutorial](https://github.com/Unity-Technologies/Robotics-Object-Pose-Estimation). A basic familiarity on these two tutorials and [ROS Tutorial](http://wiki.ros.org/ROS/Tutorials) would help better working with FetchGamePhysics.  


  - [Part 1: Installation Instruction](#part-1-installation-instruction)
  - [Part 2: ROS–Unity Integration](#part-2-rosunity-integration)
  - [Part 3: Pick-and-Place In Unity](#part-3-pick-and-place-in-unity)


## [Part 1: Installation Instruction](1_installation_instruction.md)



2. The game has been tested on publishing the robot state, target pose, and target placement pose to ROS. Select Publisher game object in the Hierarchy view, check `Source Destination Publisher`, and uncheck `Trajectory Planner` (currently in deve). Please refer to [SourceDestinationPublisher](https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/2_ros_tcp.md) if you want to know how `Source Destination Publisher` works. 

3. Select `Button` game object in Hierarchy view under `Canvas`. In the `Inspector` view, `On click ()`, switch to `SourceDestinationPublisher.Publish`. 

![UI_setup](https://github.com/JohnsonLabJanelia/FetchGamePhysics/blob/main/images/UI_setup.png)


## [Part 2: ROS–Unity Integration](2_ros_unity_integration.md)

### Running the game 
1. Open a terminal window in the ROS `catkin` workspace. Then run the following command 
```
roslaunch ur_moveit part_2.launch
```
2. Return to Unity, and press play. Click the UI `Publish` Button in the Game view. 
ROS and Unity have now sucessfully connected! 

![RosUnityIntegration](https://github.com/JohnsonLabJanelia/FetchGamePhysics/blob/main/images/RosUnityIntegration.png)

## [Part 3: Pick-and-Place In Unity](3_pick_and_place.md)


### NEW Pick and place demo


## TODO
- [x] Trajectory planner for picking up the cube and place it on the goal.
- [ ] Integration with ur_rtde and UR offline simulator. 
- [ ] Integration with real robot. 
