using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMonster : MonoBehaviour
{
    private bool start;
    public GameObject monster;
    public Transform playerTransfrom;
    public MyPlayerHealth playerHealth;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        start = true;
    }

    void OnBecameVisible()
    {
        if(start)
        {
            Debug.Log("Visible");
            GameObject aMonster = Instantiate(monster, new Vector3(x,y,0), Quaternion.identity); 
            aMonster.GetComponent<MyEnemyMovement>().player = playerTransfrom;
            aMonster.GetComponent<MyEnemyMovement>().playerHealth = playerHealth;
            start = false;
        }
        
    }
}
