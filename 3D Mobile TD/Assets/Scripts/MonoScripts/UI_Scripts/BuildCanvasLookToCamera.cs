using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCanvasLookToCamera : MonoBehaviour
{
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        transform.LookAt(transform.position + mainCam.transform.rotation * Vector3.forward, mainCam.transform.rotation * Vector3.up);
    }
}
