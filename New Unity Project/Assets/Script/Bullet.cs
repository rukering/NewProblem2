using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletshot = 6.0f;
    
    private void OnEnable()
    {
        transform.position = new Vector3(-7, 0, 0);
    }
    void Update()
    {
        transform.Translate(Vector3.right * bulletshot * Time.deltaTime);
    }

}
