using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour
{

    public RageLVL5monster mons;
    public bool isLeft = false;


    private void Start()
    {
        mons = gameObject.GetComponentInParent<RageLVL5monster>();

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
                mons.Attack(false);

            else
                mons.Attack(true);
        }
    }
}
