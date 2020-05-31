using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStage : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnColliderExit2D(Collider2D other) {
        lockCameraPos();
        // scaleCam();
        lockArea();
    }


    private void lockCameraPos(){
        // not working 
        Vector3 oldPos = Camera.main.gameObject.transform.position;
        Vector3 newPos = new Vector3(450f, oldPos.y, oldPos.z);
    }

    private void lockArea(){
        // disable trigger 
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    private void scaleCam(){
        // might not working 
        
    }
}
