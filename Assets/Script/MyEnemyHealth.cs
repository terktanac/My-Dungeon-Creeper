using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyHealth : MonoBehaviour
{
    public int health = 80;

    public GameObject deathEffect;

    [SerializeField] private bool isInvincible = false;
    [SerializeField] private bool isSpecialUnit = false;

    private void Awake() {
        MyBossMovement.numOfSkeletons += 1;
    }

    private void Start() {
        if (isSpecialUnit){
            isInvincible = true;
        }
    }

    public void TakeDamage (int damage)
    {

        if (!isInvincible)
            health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die() 
    {
        if (deathEffect != null){
            GameObject boom = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(boom, 0.25f);
        }
            
        Destroy(gameObject);
        MyBossMovement.numOfSkeletons -= 1;
    }

    public bool getInvincible(){
        return isInvincible;
    }

    public void setInvincible(bool invinc){
        isInvincible = invinc;
    }

    public bool isSpecial(){
        return isSpecialUnit;
    }
}
