using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public Transform target;

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(target.transform.position.x,
                                         target.transform.position.y, 
                                         transform.position.z);
    }
}
