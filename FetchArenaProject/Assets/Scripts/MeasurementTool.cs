using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasurementTool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 object_size = GetComponent<Collider>().bounds.size;
        Debug.Log(object_size.x);
        Debug.Log(object_size.y);
        Debug.Log(object_size.z);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
