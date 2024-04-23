using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // 플레이어 이동 속도

    void Update()
    {
        // 키 입력을 감지하여 플레이어 이동
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 카메라가 오른쪽으로 45도 회전했으므로, 이동 방향을 해당 방향으로 변환
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // 카메라의 forward 방향에서 y 축 성분 제거
        cameraForward.y = 0f;
        cameraForward.Normalize();

        // 카메라의 right 방향에서 y 축 성분 제거
        cameraRight.y = 0f;
        cameraRight.Normalize();

        // 수평 방향의 이동 벡터 계산 (x와 z 축으로만 이동)
        Vector3 moveDirection = (cameraRight * horizontalInput + cameraForward * verticalInput).normalized;

        // 이동 적용
        Move(moveDirection);
    }

    void Move(Vector3 direction)
    {
        // 플레이어 이동
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
