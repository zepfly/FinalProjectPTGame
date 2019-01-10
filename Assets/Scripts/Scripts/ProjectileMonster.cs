using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMonster : MonoBehaviour
{
    public float lifetime = 2;
    public Player player;
    public int damage = 10;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        if (lifetime <= 0)
            gameObject.GetComponent<Animator>().SetBool("Destroy", true);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
