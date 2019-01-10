using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSkillNormal : MonoBehaviour
{
    public int dmg = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("Enemy"))
        {
            collision.SendMessage("Damaged", dmg);
        }

        if (!collision.CompareTag("Player") && (collision.CompareTag("Platform") || collision.CompareTag("Enemy")))
        {
            Destroy(this.gameObject);
        }
    }
}
