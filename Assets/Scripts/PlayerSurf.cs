using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSurf : MonoBehaviour
{
    float surfDelay = 0.3f;
    public bool isSurf = false;
    public float power = 100f;

    public Animator anim;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isSurf && player.isGround)
        {
            isSurf = true;
            surfDelay = 0.3f;
        }

        if (isSurf)
        {
            if (surfDelay > 0)
            {
                surfDelay -= Time.deltaTime;
            }
            else
            {
                isSurf = false;
            }
        }

        anim.SetBool("IsSurf", isSurf);
    }

    private void FixedUpdate()
    {
        if (isSurf)
        {
            player.Surf(power);
        }
    }
}
