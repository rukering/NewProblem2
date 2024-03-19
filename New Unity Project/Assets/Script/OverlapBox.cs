using UnityEngine;

public class OverlapBox : MonoBehaviour
{
    public Vector3 size = new Vector3(1, 2, 1); // ������ �ڽ��� ũ��
    public GameManager gameManager; // GameManager ����

    void Update()
    {
        // ���� ������Ʈ�� ��ġ�� ������
        Vector3 boxPosition = transform.position;

        // ������Ʈ�� ��ġ�� ��� �ݶ��̴��� ������
        Collider[] colliders = Physics.OverlapBox(boxPosition, size / 2);

        // �� �ݶ��̴��� ���� ó��
        foreach (Collider collider in colliders)
        {
            // ��ģ �ݶ��̴��� �Ѿ����� Ȯ��
            if (collider.gameObject.name == "Bullet(Clone)")
            {
                // GameManager�� �Ѿ� ��ȯ �Լ��� ���� ȣ��
                gameManager.ReturnBullet(collider.gameObject);
            }
        }
    }
}
