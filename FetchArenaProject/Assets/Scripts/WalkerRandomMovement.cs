using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mujoco;

public class WalkerRandomMovement : MonoBehaviour
{
    public MjActuator[] actuators;
    // Start is called before the first frame update
    void Start()
    {
        actuators = GetComponentsInChildren<MjActuator>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (MjActuator actuator in actuators)
        {
            actuator.Control = UnityEngine.Random.Range(-1f, 1f);
        }
    }
}
