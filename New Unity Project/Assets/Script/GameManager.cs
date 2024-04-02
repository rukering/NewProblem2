using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public TextMeshPro BulletCount;
    public int poolSize = 10;
    
    private QueueStack<GameObject> bulletPool = new QueueStack<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            bullet.SetActive(false);
            bulletPool.Push(bullet);
        }
    }

    void Update()
    {
        if (bulletPool.Count > 0) BulletCount.text = "Bullet Count : " + bulletPool.Count;
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Pop();
            bullet.SetActive(true);
        }
        else
        {
            Debug.Log("남은 총알 없음");
            BulletCount.text = "Bullet pool is empty.";
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Push(bullet);
    }
}
