using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public GameObject cameraRoot;
    
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = cameraRoot.transform.position;
    }
}
