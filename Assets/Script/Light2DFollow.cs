using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light2DFollow : MonoBehaviour
{
    public Transform target;
    public float offset = 2;


    private Vector3 targetCurrentPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetCurrentPos = target.position;

        Vector2 newPos = new Vector2(targetCurrentPos.x,targetCurrentPos.y+offset);
        transform.position = newPos; 
        
    }
}
