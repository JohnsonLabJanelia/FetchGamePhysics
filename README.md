# FetchGamePhysics
![Digital Twin](https://github.com/JohnsonLabJanelia/FetchGamePhysics/blob/main/images/rig_room.png)


## Getting Started 
This repo is built upon [FetchGame](https://github.com/JohnsonLabJanelia/FetchGame). Many inspirations are taken from [Unity-Robotics-Hub](https://github.com/Unity-Technologies/Unity-Robotics-Hub), especially the [Pick-and-Place Tutorial](https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/README.md) and [Object Pose Estimation Tutorial](https://github.com/Unity-Technologies/Robotics-Object-Pose-Estimation). A basic familiarity on these two tutorials and [ROS Tutorial](http://wiki.ros.org/ROS/Tutorials) would help better working with FetchGamePhysics.  

## Installation Instruction 
0. Clone the repo 
1. Preparing ROS environment
3. Preparing Unity 
4. Running the game 

### Clone the repo 


### Preparing ROS environment 
The repo is tested with [ROS NOETIC](http://wiki.ros.org/noetic) on Ubuntu 20.04. We are planning on release a docker image for the game in the future. But for development purpose, it is better to have a local ros workspace. Adapted from O[ption B: Manual Setup] (https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/0_ros_setup.md). 

1. Install Noetic [Desktop-Full Install](http://wiki.ros.org/noetic/Installation/Ubuntu) on Ubuntu, and create a **ROS catkin workspace**. 
2. Install libraries

```
sudo apt-get install python3-pip ros-noetic-robot-state-publisher ros-noetic-moveit ros-noetic-rosbridge-suite ros-noetic-joy ros-noetic-ros-control ros-noetic-ros-controllers
sudo -H pip3 install rospkg jsonpickle
```
3. Copy the `ROS/src/*` from the repo into catkin workspace. 
4. 
