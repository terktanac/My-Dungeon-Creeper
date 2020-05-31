using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightController : MonoBehaviour
{

    [SerializeField] private Light2D playerLight;

    private float[] outerLightRadius = {3f,5f,7f};
    private float[] innerLightRadius = {0.3f,0.5f,0.7f};
    private int state = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // init: unefficient update 
        playerLight.pointLightOuterRadius = outerLightRadius[state];
        playerLight.pointLightInnerRadius = innerLightRadius[state];
    }

    public void OnPickLight(){
        state = Mathf.Min(2,state+1);
        FireManager.instance.UpdateFire(state);
    } 

    public int getState(){
        return state;
    }

    public void OnUseLight(){
        state = Mathf.Max(0,state-1);
        FireManager.instance.UpdateFire(state);
    }

}
