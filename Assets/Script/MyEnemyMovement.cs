using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyEnemyMovement : MonoBehaviour
{
    public Transform player;
    public MyPlayerHealth playerHealth;
    public bool isFlipped = false;
    public int damage = 1;
    [SerializeField] private float attackingDelay = 0.2f;
    private MyEnemyHealth myHealth;
    
    private bool isAttacking = false;


    void Start(){
        myHealth = gameObject.GetComponent<MyEnemyHealth>();
    }   

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    void OnCollisionStay2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player"){
            Debug.Log("Hurt");
            StartCoroutine(Attack());
        }
    }


    IEnumerator Attack()
    {
        if (playerHealth != null && !isAttacking)
        {
            isAttacking = true;
            Debug.Log("call take");
            if (transform.position.x > player.position.x)
            {
                playerHealth.TakeDamage(damage,true);
                //Debug.Log("go left");
            }
            else
            {
                playerHealth.TakeDamage(damage,false);
                //Debug.Log("go right");
            }
            yield return new WaitForSeconds(attackingDelay);
            isAttacking = false;
        }
    }


}
