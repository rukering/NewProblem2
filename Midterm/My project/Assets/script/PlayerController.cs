using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // �÷��̾� �̵� �ӵ�

    void Update()
    {
        // Ű �Է��� �����Ͽ� �÷��̾� �̵�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ī�޶� ���������� 45�� ȸ�������Ƿ�, �̵� ������ �ش� �������� ��ȯ
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // ī�޶��� forward ���⿡�� y �� ���� ����
        cameraForward.y = 0f;
        cameraForward.Normalize();

        // ī�޶��� right ���⿡�� y �� ���� ����
        cameraRight.y = 0f;
        cameraRight.Normalize();

        // ���� ������ �̵� ���� ��� (x�� z �����θ� �̵�)
        Vector3 moveDirection = (cameraRight * horizontalInput + cameraForward * verticalInput).normalized;

        // �̵� ����
        Move(moveDirection);
    }

    void Move(Vector3 direction)
    {
        // �÷��̾� �̵�
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
