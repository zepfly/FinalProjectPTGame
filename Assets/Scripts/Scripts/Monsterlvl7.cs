using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterlvl7 : MonoBehaviour
{
    public int curHealth = 6;
    public float speed;
    public float distance;
    public float attackrage;
    public bool isFaceRight = true;
    public bool attack = false;

    public float timer = 0;
    public float timecounter = 0;
    private Transform target;
    private Animator anim;
 
    public float changeDirection = -1;
    public float timechangedir;
    private void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame

    void Update()
    {
        timecounter += Time.deltaTime;
        anim.SetBool("Attack", attack);

        

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

        

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (attack && target.transform.position.x > transform.position.x && isFaceRight)
            Flip();
        if (attack && target.transform.position.x < transform.position.x && !isFaceRight)
            Flip();


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
}
