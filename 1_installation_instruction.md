# Installation Instruction 

**Table of Contents**
  - [Clone the game](#clone-the-game)
  - [Preparing ROS environment](#preparing-ros-environment)
  - [Preparing Unity ](#preparing-unity)

---


## Clone the game 
```
git clone --recurse-submodules https://github.com/JohnsonLabJanelia/FetchGamePhysics.git
```

## Preparing ROS environment 
The repo is tested with [ROS NOETIC](http://wiki.ros.org/noetic) on Ubuntu 20.04. We are planning on release a docker image for the game in the future. But for development purpose, it is better to have a local ros workspace. Adapted from O[ption B: Manual Setup](https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/0_ros_setup.md). 

1. Install Noetic [Desktop-Full Install](http://wiki.ros.org/noetic/Installation/Ubuntu) on Ubuntu, and create a **ROS catkin workspace**. 
2. Install libraries

```
sudo apt-get install python3-pip ros-noetic-robot-state-publisher ros-noetic-moveit ros-noetic-rosbridge-suite ros-noetic-joy ros-noetic-ros-control ros-noetic-ros-controllers
sudo -H pip3 install rospkg jsonpickle
```
3. Copy folders in `FetchGamePhysics/ROS/src/*` into catkin workspace. 
4. Built and sourced the ROS workspace, `catkin_make && source devel/setup.bash`. 

## Preparing Unity 
1. Open the FetchArenaProject in Unity. The **SampleScene** with robot should automatically load. If you want to know how the scene is assembled, please check [Setting up the Unity Scene](https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/1_urdf.md).
![Digital Twin](https://github.com/JohnsonLabJanelia/FetchGamePhysics/blob/main/images/rig_room.png)
 

2. Check if you have correct packages installed. 

![Package Manager](https://github.com/JohnsonLabJanelia/FetchGamePhysics/blob/main/images/package_manager.png)

The game uses *The Universal Render Pipeline*, and new physics solver `Temporal Gauss Seidel`.  

