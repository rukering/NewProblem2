using UnityEngine;

public class OverlapBox : MonoBehaviour
{
    public Vector3 size = new Vector3(1, 2, 1); // 오버랩 박스의 크기
    public GameManager gameManager; // GameManager 변수

    void Update()
    {
        // 현재 오브젝트의 위치를 가져옴
        Vector3 boxPosition = transform.position;

        // 오브젝트와 겹치는 모든 콜라이더를 가져옴
        Collider[] colliders = Physics.OverlapBox(boxPosition, size / 2);

        // 각 콜라이더에 대해 처리
        foreach (Collider collider in colliders)
        {
            // 겹친 콜라이더가 총알인지 확인
            if (collider.gameObject.name == "Bullet(Clone)")
            {
                // GameManager의 총알 반환 함수를 직접 호출
                gameManager.ReturnBullet(collider.gameObject);
            }
        }
    }
}
