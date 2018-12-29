using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            soundManager.PlaySound("crash");
            Destroy(gameObject);
        }
    }
    void Damaged(int dmg)
    {
        health -= dmg;
    }
}
