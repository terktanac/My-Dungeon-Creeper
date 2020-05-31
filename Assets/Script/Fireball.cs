using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 20f;
    private float time = 0.25f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float timeStart = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;    
    }

    private void Update() {
        timeStart += Time.deltaTime;
        if(Mathf.Round(timeStart) == 5f) {
            GameObject boom = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(boom,time);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Debug.Log(hitInfo.name);
        if (hitInfo.tag == "Player")
        {
            MyPlayerHealth playerHealth = hitInfo.GetComponent<MyPlayerHealth>();
            Transform playerTransform = hitInfo.GetComponent<Transform>();
            if (playerHealth != null)
            {
                if (transform.position.x > playerTransform.position.x)
                {
                    playerHealth.TakeDamage(damage,true);
                    //Debug.Log("go left");
                }
                else
                {
                    playerHealth.TakeDamage(damage,false);
                    //Debug.Log("go right");
                }
            }
            
            GameObject boom = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(boom,time);
        }
    }
}
