using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraAction : MonoBehaviour
{
    public GameObject Target; //카메라가 따라다닐 타겟 

    public float offsetX = 0.0f; //카메라의 좌표 X
    public float offsetY = 10.0f; //카메라의 좌표 Y
    public float offsetZ = -10.0f; //카메라의 좌표 Z

    public float angleX = 0.0f; //카메라 앵글 X
    public float angleY = 0.0f; //카메라 앵글 Y
    public float angleZ = 0.0f; //카메라 앵글 Z

    public float cameraSpeed = 10.0f; //카메라의 속도
    Vector3 TargetPos; //타겟의 위치

    private void FixedUpdate()
    {
        //타겟의 x,y,z 좌표에 카메라 좌표를 더하여 카메라의 위치를 결정
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ);
        //카메라의 움직임을 부드럽게 하는 함수Lerp
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime);
        transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);
    }
}
