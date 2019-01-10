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

    public GameObject bullet;
    private Transform target;
    private Animator anim;
    public Transform shootpointL, shootpointR;


    // Start is called before the first frame update

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("Died", died);

        RangeCheck();

        if (health < 0)
        {
            Destroy(gameObject);
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
            direction = new Vector2(direction.x, 0);
            Vector2 right = new Vector2(1, 0);
            Vector2 left = new Vector2(-1, 0);
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

    public void Damage(int dmg)
    {
        health -= dmg;
        gameObject.GetComponent<Animation>().Play("redflash");
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

}
