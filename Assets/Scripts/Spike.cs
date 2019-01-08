using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Player player;
    public int damage = 1;

    // Start is called before the first frame update
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
        }
    }
}
