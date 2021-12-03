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
The repo is tested with [ROS NOETIC](http://wiki.ros.org/noetic) on Ubuntu 20.04. We are planning on release a docker image for the game in the future. But for development purpose, it is better to have a local ros workspace. Adapted from O[ption B: Manual Setup] (https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/0_ros_setup.md). 

1. Install Noetic [Desktop-Full Install](http://wiki.ros.org/noetic/Installation/Ubuntu) on Ubuntu, and create a **ROS catkin workspace**. 
2. Install libraries

```
sudo apt-get install python3-pip ros-noetic-robot-state-publisher ros-noetic-moveit ros-noetic-rosbridge-suite ros-noetic-joy ros-noetic-ros-control ros-noetic-ros-controllers
sudo -H pip3 install rospkg jsonpickle
```
3. Copy folders in `FetchGamePhysics/ROS/src/*` into catkin workspace. 
4. Built and sourced the ROS workspace, `catkin_make && source devel/setup.bash`. 

### Preparing Unity 
Open the FetchArenaProject in Unity. The **SampleScene** with robot should automatically load. Check if you have these packages installed.
![Package Manager](https://github.com/JohnsonLabJanelia/FetchGamePhysics/blob/main/images/rig_room.png)




The game is currently tested with publishing the robot state and 
