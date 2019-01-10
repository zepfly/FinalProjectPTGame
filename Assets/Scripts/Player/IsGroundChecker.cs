using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundChecker : MonoBehaviour
{
    public Player player;
    public MovingTile mov;

    public Vector3 movep;

    // Start is called before the first frame update
    void Start()
    {
        mov = GameObject.FindGameObjectWithTag("MovingPlat").GetComponent<MovingTile>();
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
            player.isGround = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            if (mov != null)
            {
                movep = player.transform.position;
                movep.x += mov.speed * 1.3f;
                player.transform.position = movep;
            }
            player.isGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger)
            player.isGround = false;
    }
}
