using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraAction : MonoBehaviour
{
    private RotateToMouse rotateToMouse; //마우스 이동으로 카메라 회전
    private Zoom zoom;

    private void Awake()
    {
        rotateToMouse = GetComponent<RotateToMouse>();
        zoom = GetComponentInChildren<Zoom>();
    }
    private void Update()
    {
        UpdateRotate();
        UpdateZoom();
    }

    void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotateToMouse.CalculateRotation(mouseX, mouseY);
    }

    void UpdateZoom()
    {
        float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");
        zoom.ZoomInOut(t_zoomDirection);
    }
}
