using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call4Skeletons : MonoBehaviour
{
    bool start;
    public GameObject skeleton;
    public Transform playerTransfrom;
    public MyPlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        start = true;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Player" && start)
        {
            Debug.Log("Summon");
            GameObject[] skeletons = new GameObject[4];
            skeletons[0] = Instantiate(skeleton, new Vector3(75,0,0), Quaternion.identity); 
            skeletons[1] = Instantiate(skeleton, new Vector3(79,0,0), Quaternion.identity);
            skeletons[2] = Instantiate(skeleton, new Vector3(89,0,0), Quaternion.identity);
            skeletons[3] = Instantiate(skeleton, new Vector3(93,0,0), Quaternion.identity);
            for(int i = 0; i < 4; i++)
            {
                skeletons[i].GetComponent<MyEnemyMovement>().player = playerTransfrom;
                skeletons[i].GetComponent<MyEnemyMovement>().playerHealth = playerHealth;
            }
            start = false;
        }
    }
}
