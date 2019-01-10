using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUltimate : MonoBehaviour
{
    public int dmg = 50;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("Enemy"))
        {
            collision.SendMessage("Damaged", dmg);
        }
    }
}
