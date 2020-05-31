using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBossMovement : MonoBehaviour
{
    public Transform playerTransfrom;
    public Transform bossTransfrom;
    public Animator animator;
    public GameObject fireball;
    public float fireRate = 5f;
    public GameObject skeleton;
    public MyPlayerHealth playerHealth;
    public static int numOfSkeletons = 0;
    private bool isRunning = false;
    private bool isHalo = false;
    private int count = 0;
    private float move = -1;
    private bool FacingRight = false;
    private Vector3 Velocity = Vector3.zero;
    private Rigidbody2D rb;
    float[] pos1 = new float[]{430f,432.5f,435f,437.5f,440f};
    float[] pos2 = new float[]{445f,447.5f,450f,452.5f,455f};
    float[] pos3 = new float[]{460f,462.5f,465f,467.5f,470f};
    // Start is called before the first frame update

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        animator.SetBool("isHalo",isHalo);
    }

    // Update is called once per frame
    void Update() {
        if (!isRunning && !isHalo) {
            if(count == 2) {
                count = 0;
                isHalo = !isHalo;
                animator.SetBool("isHalo",isHalo);
            }
            else {
                count++;
            }
            StartCoroutine(BossWait());
        }
        else if(!isRunning) {
            if(count == 2) {
                count = 0;
                isHalo = !isHalo;
                animator.SetBool("isHalo",isHalo);
            }
            else {
                count++;
            }
            StartCoroutine(HaloWait());
        }
    }

    private void FixedUpdate() {
        if(isHalo) {
            Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref Velocity, 0);
            if(Mathf.RoundToInt(bossTransfrom.position.x)  <= 435) {
                move = 1;
            }
            else if(Mathf.RoundToInt(bossTransfrom.position.x) >= 465) {
                move = -1;
            }
            if (move > 0 && !FacingRight) {
                Flip();
            }
            else if (move < 0 && FacingRight) {
                Flip();
            }
        }
        else {
            if(Mathf.RoundToInt(bossTransfrom.position.x) == 460) {
                move = -1;
                Debug.Log("stay");
                 rb.velocity = Vector3.zero;
            }
            else {
                Debug.Log("not stay");
                Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref Velocity, 0);
                if(Mathf.RoundToInt(bossTransfrom.position.x)  <= 435) {
                move = 1;
                }
                else if(Mathf.RoundToInt(bossTransfrom.position.x) >= 460) {
                    move = -1;
                }
            }
            if (move > 0 && !FacingRight) {
                Flip();
            }
            else if (move < 0 && FacingRight) {
                Flip();
            }
        }
    }

    public void Attack()
    {
        Instantiate(fireball, new Vector3(458, 8), Quaternion.AngleAxis(90, Vector3.forward));  
        Instantiate(fireball, new Vector3(458, 8), Quaternion.AngleAxis(135, Vector3.forward)); 
        Instantiate(fireball, new Vector3(458, 8), Quaternion.AngleAxis(180, Vector3.forward));
        Instantiate(fireball, new Vector3(458, 8), Quaternion.AngleAxis(225, Vector3.forward));  
        Instantiate(fireball, new Vector3(458, 8), Quaternion.AngleAxis(270, Vector3.forward));   
    }

    public void Summon()
    {
        GameObject[] skeletons = new GameObject[4];
            skeletons[0] = Instantiate(skeleton, new Vector3(453,0,0), Quaternion.identity); 
            skeletons[1] = Instantiate(skeleton, new Vector3(455,0,0), Quaternion.identity);
            skeletons[2] = Instantiate(skeleton, new Vector3(465,0,0), Quaternion.identity);
            skeletons[3] = Instantiate(skeleton, new Vector3(467,0,0), Quaternion.identity);
            for(int i = 0; i < 4; i++)
            {
                skeletons[i].GetComponent<MyEnemyMovement>().player = playerTransfrom;
                skeletons[i].GetComponent<MyEnemyMovement>().playerHealth = playerHealth;
            }
    }

    IEnumerator BossWait()
    {
        isRunning = true;
        Attack();
        yield return new WaitForSeconds(2f);
        Attack();
        yield return new WaitForSeconds(2f);
        Attack();
        yield return new WaitForSeconds(1f);
        if(numOfSkeletons < 12)
        Summon();
        yield return new WaitForSeconds(1f);
        isRunning = false;
    }

    IEnumerator HaloWait()
    {
        isRunning = true;
        for(int i = 0; i < 20; i++)
        {
            int pos = Mathf.RoundToInt(Random.Range(0f, 4f));
            Instantiate(fireball, new Vector3(pos1[pos], 16), Quaternion.AngleAxis(270, Vector3.forward)); 
            pos = Mathf.RoundToInt(Random.Range(0f, 4f)); 
            Instantiate(fireball, new Vector3(pos2[pos], 16), Quaternion.AngleAxis(270, Vector3.forward)); 
            pos = Mathf.RoundToInt(Random.Range(0f, 4f)); 
            Instantiate(fireball, new Vector3(pos3[pos], 16), Quaternion.AngleAxis(270, Vector3.forward));  
            yield return new WaitForSeconds(0.5f);
        }
        isRunning = false;
    }

    private void Flip()
	{
		FacingRight = !FacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
