using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mujoco;

public class BallRandomMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Translate(new Vector3(0.3f, 0f, 0.3f));
        // MjScene scene = GameObject.Find("MjScene").GetComponent<MjScene>();
    }

}
