using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private Vector3 _dir;
    [SerializeField] private CameraData _cameraSattingsData;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        CameraMoveMethod();
        CameraBorderMethod();
        TargetMoveMethod();

        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }
    }

    private void CameraMoveMethod()
    {
        _camera.transform.position = Vector3.Lerp(transform.position, transform.position, Time.deltaTime * _cameraSattingsData.cameraSmoothSpeed);
    }

    private void CameraBorderMethod()
    {
        if (transform.position.x <= _cameraSattingsData.cameraMinX)
        {
            transform.position = new Vector3(_cameraSattingsData.cameraMinX, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= _cameraSattingsData.cameraMaxX)
        {
            transform.position = new Vector3(_cameraSattingsData.cameraMaxX, transform.position.y, transform.position.z);
        }

        if (transform.position.z <= _cameraSattingsData.cameraMinZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _cameraSattingsData.cameraMinZ);
        }

        if (transform.position.z >= _cameraSattingsData.cameraMaxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _cameraSattingsData.cameraMaxZ);
        }
    }

    private void TargetMoveMethod()
    {
        _dir = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        transform.Translate(_dir * _cameraSattingsData.cameraMovingSpeed * Time.deltaTime);
    }


}
