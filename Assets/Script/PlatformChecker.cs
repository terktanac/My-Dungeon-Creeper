using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChecker : MonoBehaviour
{

    private PlatformEffector2D effector;
    private BoxCollider2D box;
    private bool isCollide;
    private bool isRunning = false;
    private bool colliderDisable = false;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // reset
        if(!isRunning)
        {
            effector.rotationalOffset = 0f;
        }

        // s key down 
        if(Input.GetKeyDown(KeyCode.S)){
            if(!isRunning){
                effector.rotationalOffset = 180f;
                StartCoroutine(delay(0.5f));
            }
        }
    }

    private IEnumerator delay(float time)
    {
        isRunning = true;
        yield return new WaitForSeconds(time);
        isRunning = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
        float y = transform.position.y;
        float colY = col.gameObject.transform.position.y;
        if(col.gameObject.tag == "Player" && (y-colY)>=0){
            box.enabled = false;
            StartCoroutine(delay(3f));
            box.enabled = true;
            Debug.Log("lol");
        }
    }
}
