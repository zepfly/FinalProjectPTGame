using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;

    private float attackDelay = 0.3f;

    private float distance;
    public float bulletspeed = 5;
    public float bullettimer;
    public float shootinterval;
    public bool isshooting = false;
    private bool canshoot = true;
    public float speed = 2;


    public bool isPowered = false;

    private bool died = false;
    public bool lookingRight = false;
    public bool isFaceRight = false;
    public bool power = false;

    public float moveTimer;
    public float timecount = 0;
    public Transform p1;
    public Transform p2;

    public GameObject bullet;
    public GameObject aura;
    public Transform target;
    public Animator anim;
    public Transform shootpointL, shootpointR;
    // Start is called before the first frame update

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        aura.SetActive(false);
        
    }

    void Awake()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Dead", died);
        timecount += Time.deltaTime;
        if (isPowered)
            aura.SetActive(true);
        Power();
        if (health < 0)
        {
            aura.SetActive(false);
            died = true;
        }
        if (!died)
        {
            if (timecount <= moveTimer / 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, p1.position, speed);

            }
            else if (timecount <= moveTimer)
                transform.position = Vector2.MoveTowards(transform.position, p2.position, speed);
            else if (timecount <= moveTimer * 1.5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, p1.position, speed);
            }
            else { 
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(6.57f, -0.97f, 0), speed);
            }

            if (timecount >= 2.3f * moveTimer)
                timecount = 0;
            if (isshooting)
            {
                if (attackDelay > 0)
                {
                    attackDelay -= Time.deltaTime;
                }
                else
                {
                    isshooting = false;
                    attackDelay = 0.10f;
                }
            }
            if (isPowered)
                anim.SetBool("PAttack", isshooting);
            else
                anim.SetBool("Attack", isshooting);
        }
    }



    public void Power()
    {
        if(!isPowered && health < 100)
        {
            
            anim.SetBool("Power", true);
            isPowered = true;
        }
        else
        {
            anim.SetBool("Power", false);
        }
        
    }

    public void Attack(bool attackright)
    {
        bullettimer += Time.deltaTime;
       

        if (target.transform.position.x > transform.position.x && !isFaceRight)
            Flip();
        if (target.transform.position.x < transform.position.x && isFaceRight)
            Flip();
        if (bullettimer >= shootinterval - 0.5f && canshoot)
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
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
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

    void Damaged(int dmg)
    {
        health -= dmg;
    }

    void BulletFlip()
    {
        bullet.transform.localScale = new Vector3(bullet.transform.localScale.x * -1, bullet.transform.localScale.y, bullet.transform.localScale.z);
    }

    void Flip()
    {
        isFaceRight = !isFaceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        bullet.transform.localScale = new Vector3(bullet.transform.localScale.x * -1, bullet.transform.localScale.y, bullet.transform.localScale.z);

    }

    void Destroy()
    {

        Destroy(this.gameObject);
    }
}
