using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLight : MonoBehaviour
{
    public GameObject refLight;
    private bool isPressed = false;
    private bool isDelay = false;
    [SerializeField] private lightController lightCtrl;
    public GameObject callBossObject;
    CallBoss callBoss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player" && Input.GetKeyDown("f") && !isPressed && lightCtrl.getState()>0 )
        {

            StartCoroutine(delay());
            lightCtrl.OnUseLight();
            callBoss = callBossObject.GetComponent<CallBoss>();
            callBoss.updateCountLamp();
        }
    }

    IEnumerator delay(){

        isPressed = true;

        refLight.SetActive(!refLight.activeSelf);   // on
        yield return new WaitForSeconds(0.5f);
        refLight.SetActive(!refLight.activeSelf);   // off
        yield return new WaitForSeconds(2f);
        refLight.SetActive(!refLight.activeSelf);   // on
        yield return new WaitForSeconds(0.5f);
        refLight.SetActive(!refLight.activeSelf);   // off
        yield return new WaitForSeconds(1f);
        refLight.SetActive(!refLight.activeSelf);

    }
}
