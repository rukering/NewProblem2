using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;        // 플레이어 오브젝트의 Transform 컴포넌트
    public float rotationAmount = 90.0f;  // 회전 각도
    public float rotationSpeed = 90.0f;   // 회전 속도

    private Quaternion targetRotation;  // 목표 회전 상태

    void Update()
    {
        // E 키를 입력받으면 플레이어의 up 벡터를 축으로 오른쪽으로 90도 회전
        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateCameraAroundPlayer(player.up, rotationAmount);
        }

        // Q 키를 입력받으면 플레이어의 up 벡터를 축으로 왼쪽으로 90도 회전
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateCameraAroundPlayer(player.up, -rotationAmount);
        }

        // 부드러운 회전을 위해 현재 회전 상태에서 목표 회전 상태로 회전
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void RotateCameraAroundPlayer(Vector3 axis, float angle)
    {
        // 현재 카메라의 회전 각도를 가져옴
        Quaternion currentRotation = transform.rotation;

        // 목표 회전 각도 계산
        Quaternion deltaRotation = Quaternion.AngleAxis(angle, axis);

        // 목표 회전 상태 계산
        targetRotation = deltaRotation * currentRotation;
    }

}

