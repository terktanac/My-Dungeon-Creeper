﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destryObj : MonoBehaviour
{
    [SerializeField] private float health = 80;
    [SerializeField] private CapsuleCollider2D capCol;
    [SerializeField] private Color flickerColor = Color.white;
    [SerializeField] private Color startingColor = Color.clear;
    [SerializeField] private SpriteRenderer spriteRen;
    [SerializeField] private float filckerTime = 0.1f;  // flicker time (sec)
    [SerializeField] private GameObject fire;
    private GameObject gameObj;

    // Start is called before the first frame update
    void Start()
    {
        startingColor = spriteRen.color;
        gameObj = gameObject;
        if(capCol == null)
            capCol = gameObj.GetComponent<CapsuleCollider2D>();
        if(spriteRen == null)
            spriteRen = gameObj.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkBreak()
    {
        if(health <= 0)
            Destroy(gameObj);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // FireBullet
        if (hitInfo.gameObject.tag == "bullet")
        {
            health -= hitInfo.GetComponent<Bullet>().damage;
            checkBreak();
            StartCoroutine(getHit());
        }
    }

    IEnumerator getHit()
    {
        spriteRen.color = flickerColor;
        yield return new WaitForSeconds(filckerTime);
        spriteRen.color = startingColor;
    }

    private void OnDestroy() {
        Instantiate(fire,transform.position + new Vector3(0.5f,0.5f,0), new Quaternion(0f,0f,180f,0f));
    }
}
