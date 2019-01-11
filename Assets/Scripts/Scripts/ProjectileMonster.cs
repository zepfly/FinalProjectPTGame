using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMonster : MonoBehaviour
{
    public float lifetime = 2;
    public Player player;
    public int damage = 10;
    private Transform target;
    private AudioSource aduioSource;

    private bool isFlipped = false;
    public bool isFaceRight = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        aduioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //if (player.CurrentHealth > 1)       // trick to debug easier
            player.Damaged(damage);
            player.KnockBack(320f, player.transform.position);
            gameObject.GetComponent<Animator>().SetBool("Destroy", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (player.transform.position.x > transform.position.x && isFaceRight && !isFlipped)
        {
            Flip();
            isFlipped = true;
        }
        if (player.transform.position.x < transform.position.x && !isFaceRight && !isFlipped)
        {

            Flip();
            isFlipped = true;
        }
        if (lifetime <= 0)
            gameObject.GetComponent<Animator>().SetBool("Destroy", true);
    }

    void Flip()
    {
        isFaceRight = !isFaceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }
    // this changed
    public void DestroyProjectTile()
    {
        Destroy(gameObject);
    }
}
