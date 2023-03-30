using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraAction : MonoBehaviour
{
    public GameObject Target; //ī�޶� ����ٴ� Ÿ�� 

    public float offsetX = 0.0f; //ī�޶��� ��ǥ X
    public float offsetY = 10.0f; //ī�޶��� ��ǥ Y
    public float offsetZ = -10.0f; //ī�޶��� ��ǥ Z

    public float angleX = 0.0f; //ī�޶� �ޱ� X
    public float angleY = 0.0f; //ī�޶� �ޱ� Y
    public float angleZ = 0.0f; //ī�޶� �ޱ� Z

    public float cameraSpeed = 10.0f; //ī�޶��� �ӵ�
    Vector3 TargetPos; //Ÿ���� ��ġ

    private void FixedUpdate()
    {
        //Ÿ���� x,y,z ��ǥ�� ī�޶� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ);
        //ī�޶��� �������� �ε巴�� �ϴ� �Լ�Lerp
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime);
        transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);
    }
}
