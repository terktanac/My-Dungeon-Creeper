using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGhost : MonoBehaviour
{
    private bool start;
    public GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
        start = true;
    }

    // Update is called once per frame
    void OnBecameVisible()
    {
        if(start)
        {
            Debug.Log("Visible");
            ghost.SetActive(true);
            start = false;
        }
        
    }
}
