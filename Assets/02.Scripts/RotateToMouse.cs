using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField] private float rotCamXAxisSpeed = 5f; //ī�޶� X�� ȸ���ӵ�
    [SerializeField] private float rotCamYAxisSpeed = 3f; //ī�޶� Y�� ȸ���ӵ�

    private float limitMinX = -80; //ī�޶� X�� ȸ�� ���� (�ּ�)
    private float limitMaxX = 50; //ī�޶� Y�� ȸ�� ���� (�ִ�)

    private float eulerAngleX; //���콺 ��/�� �̵����� ī�޶� Y�� ȸ��
    private float eulerAngleY;// ���콺 ��/�Ʒ� �̵����� ī�޶� X�� ȸ��

    public void CalculateRotation(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed;
        eulerAngleX -= mouseY * rotCamYAxisSpeed;
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);
        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    //ī�޶� X�� ȸ���� ��� ȸ�� ������ ����
    private float ClampAngle(float angle, float min, float max)
    {
        if(angle < -360)
        {
            angle += 360;
        }
        if(angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
