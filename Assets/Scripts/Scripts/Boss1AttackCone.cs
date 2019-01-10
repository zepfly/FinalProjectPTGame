using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AttackCone : MonoBehaviour
{
    // Start is called before the first frame update
    public Boss1 mons;
    public bool isLeft = false;


    private void Start()
    {
        mons = gameObject.GetComponentInParent<Boss1>();

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
