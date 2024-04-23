using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;        // �÷��̾� ������Ʈ�� Transform ������Ʈ
    public float rotationAmount = 90.0f;  // ȸ�� ����
    public float rotationSpeed = 90.0f;   // ȸ�� �ӵ�

    private Quaternion targetRotation;  // ��ǥ ȸ�� ����

    void Update()
    {
        // E Ű�� �Է¹����� �÷��̾��� up ���͸� ������ ���������� 90�� ȸ��
        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateCameraAroundPlayer(player.up, rotationAmount);
        }

        // Q Ű�� �Է¹����� �÷��̾��� up ���͸� ������ �������� 90�� ȸ��
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateCameraAroundPlayer(player.up, -rotationAmount);
        }

        // �ε巯�� ȸ���� ���� ���� ȸ�� ���¿��� ��ǥ ȸ�� ���·� ȸ��
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void RotateCameraAroundPlayer(Vector3 axis, float angle)
    {
        // ���� ī�޶��� ȸ�� ������ ������
        Quaternion currentRotation = transform.rotation;

        // ��ǥ ȸ�� ���� ���
        Quaternion deltaRotation = Quaternion.AngleAxis(angle, axis);

        // ��ǥ ȸ�� ���� ���
        targetRotation = deltaRotation * currentRotation;
    }

}

