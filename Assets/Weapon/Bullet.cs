using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private float time = 0.25f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float timeStart = 0;
    void Start()
    {
        rb.velocity = transform.right * speed;      
    }

    private void Update() {
        timeStart += Time.deltaTime;
        if(Mathf.Round(timeStart) == 10f) {
            GameObject boom = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(boom,time);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name != "Player" && hitInfo.name != "Tilemap" && hitInfo.tag != "Light" && hitInfo.tag != "Fire" && hitInfo.tag != "Sign")
        {
            MyEnemyHealth enemy = hitInfo.GetComponent<MyEnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            GameObject boom = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(boom,time);
        }
    }
}
