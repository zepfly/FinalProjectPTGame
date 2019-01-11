using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterlvl6 : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 200;
    public float speed;
    public float distance;
    public float attackrage;
    public bool isFaceRight = true;
    public bool attack = false;

    
    private Transform target;
    private Animator anim;
    
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
        anim.SetBool("Attack", attack);

        RageCheck();

        if(attack == true)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed);

        if (health <= 0)
        {
            anim.SetBool("Died", true);
        }

        if (target.transform.position.x > transform.position.x && isFaceRight)
            Flip();
        if (target.transform.position.x < transform.position.x && !isFaceRight)
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

    public void Damaged(int dmg)
    {

        health -= dmg;
        anim.SetTrigger("Hitted");
    }


    void DestroyGameOject()
    {
        Destroy(gameObject);
    }
}
