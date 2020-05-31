using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform crouchFirePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    [SerializeField] private BrackeyController controller;
    private Vector3 mousePos;
    private bool isFire = false;
    private bool isFlip = false;
    [SerializeField] private float fireCd = 0.1f;    // fire cooldown

    void Update()
    {
        Vector3 preFirePoint = firePoint.eulerAngles;
        Vector3 preCrouchFirePoint = crouchFirePoint.eulerAngles;
        // (isFlip, zTarget,zCrouchTarget) = checkFlip();
        if (Input.GetButtonDown("Fire1"))
        {
            if (animator.GetFloat("speed") < 0.01f)
            {
                Vector3 curPos  = transform.position;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 aimVec = (mousePos - curPos).normalized;
                
                
                if(aimVec.x < 0f && !controller.isFlip()){
                    controller.Flip();
                }
                else if(aimVec.x > 0f && controller.isFlip()){
                    controller.Flip();
                }

                firePoint.eulerAngles = new Vector3(0, 0, Mathf.Atan2(aimVec.y,aimVec.x)*Mathf.Rad2Deg);
                crouchFirePoint.eulerAngles = new Vector3(0, 0, Mathf.Atan2(aimVec.y,aimVec.x)*Mathf.Rad2Deg);
                

                // shoot 
                animator.SetTrigger("setAttacking");
                StartCoroutine(Shoot());
                
            }
        }
    }

    IEnumerator Shoot()
    {
        if (!isFire)
        {
            if(animator.GetBool("isJumping") || animator.GetBool("isCrouching"))
            {
                Instantiate(bulletPrefab,crouchFirePoint.position,crouchFirePoint.rotation);  
            }
            else
            {
                Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);            
            }
            isFire = true;
            yield return new WaitForSeconds(fireCd);
            isFire = false;
        }
        
    }
}
