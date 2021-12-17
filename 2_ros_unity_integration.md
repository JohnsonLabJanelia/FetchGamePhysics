
2. The game has been tested on publishing the robot state, target pose, and target placement pose to ROS. Select Publisher game object in the Hierarchy view, check `Source Destination Publisher`, and uncheck `Trajectory Planner` (currently in deve). Please refer to [SourceDestinationPublisher](https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/2_ros_tcp.md) if you want to know how `Source Destination Publisher` works. 

3. Select `Button` game object in Hierarchy view under `Canvas`. In the `Inspector` view, `On click ()`, switch to `SourceDestinationPublisher.Publish`. 

![UI_setup](https://github.com/JohnsonLabJanelia/FetchGamePhysics/blob/main/images/UI_setup.png)
