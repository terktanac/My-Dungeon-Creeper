using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("entere");
        Debug.Log(other.gameObject.tag);

        if(other.gameObject.tag == "Enemy")
            Debug.Log(other.gameObject.GetComponent<MyEnemyHealth>().isSpecial());

        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<MyEnemyHealth>().isSpecial()){
            Debug.Log("turn invinv off");
            other.gameObject.GetComponent<MyEnemyHealth>().setInvincible(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<MyEnemyHealth>().isSpecial()){
            other.gameObject.GetComponent<MyEnemyHealth>().setInvincible(true);
        }
    }
}
