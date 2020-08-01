using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettingsData")]
public class CameraData : ScriptableObject
{
    public float cameraZoomSpeed;
    public float cameraMovingSpeed;
    public float cameraSmoothSpeed;
    public float cameraMaxX;
    public float cameraMinX;
    public float cameraMaxZ;
    public float cameraMinZ;
    public float cameraMaxY;
    public float cameraMinY;
}
