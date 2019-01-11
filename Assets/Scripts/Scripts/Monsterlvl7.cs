using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterlvl7 : MonoBehaviour
{
    public int health = 100;
    public float speed;
    public float distance;
    public float attackrage;
    public bool isFaceRight = true;
    public bool attack = false;

    public int damage = 10;
    public float timer = 0;
    public float timecounter = 0;
    private Transform target;
    private Animator anim;
 
    public float changeDirection = -1;
    public float timechangedir;
    private Player player;
    public bool hitted = false;

    private MonsterSoundManager audioSource;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audioSource = GetComponent<MonsterSoundManager>();
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame

    void Update()
    {
        timecounter += Time.deltaTime;




        if (!attack)
        {

            this.transform.position = new Vector3(transform.position.x + speed, transform.position.y);
            if (timecounter > timechangedir)
            {
                speed *= changeDirection;
                if (speed < 0 && !isFaceRight)
                    Flip();
                else if (speed > 0 && isFaceRight)
                    Flip();
                timecounter = 0;
            }
        }

        RageCheck();

        if (attack == true)
              transform.position = Vector2.MoveTowards(transform.position, target.position, speed);

        

        if (health <= 0)
        {

            anim.SetBool("Died", true);
        }

        if (attack && target.transform.position.x > transform.position.x && isFaceRight)
            Flip();
        if (attack && target.transform.position.x < transform.position.x && !isFaceRight)
            Flip();

    }
    void FixedUpdate()
    {
        anim.SetBool("Damged", false);

    }

    void Flip()
    {
        isFaceRight = !isFaceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void RageCheck()
    {
        if (Mathf.Abs(target.transform.position.x - transform.position.x) < 5.46)
        {
            attack = true;
        }

        if (Mathf.Abs(target.transform.position.x - transform.position.x) > 5.46)
        {
            attack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //if (player.CurrentHealth > 1)       // trick to debug easier
            player.Damaged(damage);
            player.KnockBack(320f, player.transform.position);
        }

    }

    void Damaged(int dmg)
    {
        audioSource.PlaySound("hurted");
        health -= dmg;
        anim.SetTrigger("Hitted");
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
