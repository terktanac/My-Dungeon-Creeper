using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBoss : MonoBehaviour
{
    private bool start;
    public GameObject ghost1;
    public Transform playerTransfrom;
    public MyPlayerHealth playerHealth;
    private float countLamp = 0;
    // Start is called before the first frame update
    void Start()
    {
        start = true;
    }

    public void updateCountLamp() {
        countLamp += 1;
    }
    // Update is called once per frame
    void OnBecameVisible()
    {
        //if(start && countLamp == 6)
        if(start)
        {
            Debug.Log("Visible");
            GameObject boss = Instantiate(ghost1, new Vector3(460,8,0), Quaternion.identity); 
            boss.GetComponent<MyBossMovement>().playerTransfrom = playerTransfrom;
            boss.GetComponent<MyBossMovement>().playerHealth = playerHealth;
            start = false;
        }
        
    }
}
