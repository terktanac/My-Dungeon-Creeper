using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerHealth : MonoBehaviour
{

    public int health = 100;
    public Animator animator;
    public Rigidbody2D playerRigidbody2D;
    public SpriteRenderer playerSpriteRenderer;
    
    private bool isDamaged = false;

    [SerializeField] private Color flickerColor = Color.white;
    [SerializeField] private float flickerTime = 0.2f;
    [SerializeField] private float impactMultiplier = 10f;

    public void TakeDamage (int damage, bool fromRight)
    {

        if (!isDamaged)
        {
            Debug.Log("damaged!");
            if(fromRight)
            {
                playerRigidbody2D.AddForce(new Vector2(-200f * impactMultiplier, 50f));
            }
            else
            {
                playerRigidbody2D.AddForce(new Vector2(200f * impactMultiplier, 50f));
            }
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
            else
            {
                animator.SetTrigger("setHurting");
                StartCoroutine(getHit());
            }
        }
    }

    void Die() 
    {  
        Debug.Log("Die");
        gameObject.SetActive(false);
        gameObject.transform.position = new Vector3(-5,0,0);
        health = 100;
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -6)
        Die();
    }

    IEnumerator getHit()
    {
        if(!isDamaged){
            isDamaged = true;
            for(int i = 0; i < 15; i++){
                playerSpriteRenderer.color = new Color(1f,1f,1f,.5f);
                yield return new WaitForSeconds(0.1f);
                playerSpriteRenderer.color = new Color(1f,1f,1f,1f);
                yield return new WaitForSeconds(0.1f);
            }
            isDamaged = false;
        }
    }
}
