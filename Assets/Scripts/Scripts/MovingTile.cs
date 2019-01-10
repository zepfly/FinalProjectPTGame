using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    public float speed = 0.05f, changeDirection = -1;
    public float timer;
    public float timechangedir = 2;
    Vector3 Move;

    // Use this for initialization
    void Start()
    {
        Move = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Move.x += speed;
        this.transform.position = Move;
        if (timer > timechangedir)
        {

            speed *= changeDirection;
            timer = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            speed *= changeDirection;
        }
    }
}
