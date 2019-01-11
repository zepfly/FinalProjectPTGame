using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageLVL5monster : MonoBehaviour
{
    public int health = 100;

    private float attackDelay = 0.3f;

    public float distance;
    public float wakerange;
    public float bulletspeed = 5;
    public float bullettimer;
    public float shootinterval;
    public bool isshooting = false;
    private bool canshoot = true;

    public bool awake = false;
    public bool died = false;
    public bool lookingRight = true;
    public bool isFaceRight = false;
    public Rigidbody2D rigid;

    public GameObject bullet;
    private Transform target;
    private Animator anim;
    public Transform shootpointL, shootpointR;

    private MonsterSoundManager audioSource;
    // Start is called before the first frame update

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<MonsterSoundManager>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);

        RangeCheck();

        if (health < 0)
        {
            anim.SetBool("Died", true);
        }

        if (isshooting)
        {
            if (attackDelay > 0)
            {
                attackDelay -= Time.deltaTime;
            }
            else
            {
                isshooting = false;
                attackDelay = 0.3f;
            }
        }

        anim.SetBool("Attack", isshooting);
    }

    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < wakerange)
            awake = true;

        if (distance > wakerange)
            awake = false;


    }

    public void Attack(bool attackright)
    {
        bullettimer += Time.deltaTime;


        if (target.transform.position.x > transform.position.x && !isFaceRight)
            Flip();
        if (target.transform.position.x < transform.position.x && isFaceRight)
            Flip();
        if(bullettimer >= shootinterval - 0.5f && canshoot)
        {

            isshooting = true;
            canshoot = false;
        }
        if (bullettimer >= shootinterval)
        {
            canshoot = true;
            Vector2 direction = target.transform.position - transform.position;


            direction.Normalize();

            if (attackright)
            {

                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootpointR.transform.position, shootpointR.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed ;  
                bullettimer = 0;
            }
            else
            {     
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootpointL.transform.position, shootpointL.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;               
                bullettimer = 0;
            }
        }
        
       
    }

    public void Damaged(int dmg)
    {
        audioSource.PlaySound("hurted");
        health -= dmg;
        anim.SetTrigger("Hitted");
    }


    //void KnockBack(float knockPow, Vector2 knockDir)
    //{
    //    rigid.velocity = new Vector2(0, 0);

    //    if (isFaceRight)
    //        rigid.AddForce(new Vector2(Mathf.Abs(knockDir.x) * -100, Mathf.Abs(knockDir.y) * knockPow));
    //    else
    //        rigid.AddForce(new Vector2(Mathf.Abs(knockDir.x) * 100, Mathf.Abs(knockDir.y) * knockPow));
    //}

    void Flip()
    {
        isFaceRight = !isFaceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        
    }


    void DeadSound()
    {
        audioSource.PlaySound("died");
    }

    void DestroyGameOject()
    {
        Destroy(gameObject);
    }
}
