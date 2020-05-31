using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Ghost2GFX : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-7.874563f, 7.309172f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(7.874563f, 7.309172f, 1f);
        }
    }
}
