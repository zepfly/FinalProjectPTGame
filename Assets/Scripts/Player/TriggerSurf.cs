using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSurf : MonoBehaviour
{
    public int damage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("Enemy"))
        {
            collision.SendMessage("Damaged", damage);
        }
    }
}
