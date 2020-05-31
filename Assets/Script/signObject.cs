using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signObject : MonoBehaviour
{

    // ref image 
    [SerializeField] private Image canvasRefImage = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown("f")){
            if (other.gameObject.tag == "Player")
                canvasRefImage.enabled = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
            canvasRefImage.enabled = false;
    }
}
