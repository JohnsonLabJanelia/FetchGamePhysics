# FetchGamePhysics
![Digital Twin](https://github.com/JohnsonLabJanelia/FetchGamePhysics/blob/main/images/rig_room.png)


## Getting Started 
This repo is built upon [FetchGame](https://github.com/JohnsonLabJanelia/FetchGame). Many inspirations are taken from [Unity-Robotics-Hub](https://github.com/Unity-Technologies/Unity-Robotics-Hub), especially the [Pick-and-Place Tutorial](https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/README.md) and [Object Pose Estimation Tutorial](https://github.com/Unity-Technologies/Robotics-Object-Pose-Estimation). A basic familiarity on these two tutorials and [ROS Tutorial](http://wiki.ros.org/ROS/Tutorials) would help better working with FetchGamePhysics.  

## Installation Instruction 
0. Clone the repo 
1. Preparing ROS environment
2. Preparing Unity 
3. Running the game 

### Clone the game 
```
git clone --recurse-submodules https://github.com/JohnsonLabJanelia/FetchGamePhysics.git
```

### Preparing ROS environment 
The repo is tested with [ROS NOETIC](http://wiki.ros.org/noetic) on Ubuntu 20.04. We are planning on release a docker image for the game in the future. But for development purpose, it is better to have a local ros workspace. Adapted from O[ption B: Manual Setup](https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/0_ros_setup.md). 

1. Install Noetic [Desktop-Full Install](http://wiki.ros.org/noetic/Installation/Ubuntu) on Ubuntu, and create a **ROS catkin workspace**. 
2. Install libraries

```
sudo apt-get install python3-pip ros-noetic-robot-state-publisher ros-noetic-moveit ros-noetic-rosbridge-suite ros-noetic-joy ros-noetic-ros-control ros-noetic-ros-controllers
sudo -H pip3 install rospkg jsonpickle
```
3. Copy folders in `FetchGamePhysics/ROS/src/*` into catkin workspace. 
4. Built and sourced the ROS workspace, `catkin_make && source devel/setup.bash`. 

### Preparing Unity 
Open the FetchArenaProject in Unity. The **SampleScene** with robot should automatically load. If you want to know how the scene is assembled, please check [Setting up the Unity Scene](https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/1_urdf.md). 

Check if you have correct packages installed:
![Package Manager](https://github.com/JohnsonLabJanelia/FetchGamePhysics/blob/main/images/package_manager.png)

The game uses *The Universal Render Pipeline*, and new physics solver `Temporal Gauss Seidel`.  

The game has been tested on publishing the robot state, target pose, and target placement pose to ROS. Select Publisher game object in the Hierarchy view, check `Source Destination Publisher`, and uncheck `Trajectory Planner` (currently in deve). Please refer to [SourceDestinationPublisher](https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/2_ros_tcp.md) if you want to know how `Source Destination Publisher` works. 

### Running the game 
1. Open a terminal window in the ROS `catkin` workspace. Then run the following command 
```
roslaunch ur_moveit part_2.launch
```
2. Return to Unity, and press play. Click the UI `Publish` Button in the Game view. 
ROS and Unity have now sucessfully connected! 
![RosUnityIntegration](https://github.com/JohnsonLabJanelia/FetchGamePhysics/blob/main/images/RosUnityIntegration.png)


## TODO
- Trajectory planner for picking up the cube and place it on the goal.
- Integration with ur_rtde and UR offline simulator. 
- Integration with real robot. 
