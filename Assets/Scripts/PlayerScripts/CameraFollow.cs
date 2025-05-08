using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public GameObject cameraRoot;
    
    void Update()
    {
        gameObject.transform.position = cameraRoot.transform.position;
    }
}
