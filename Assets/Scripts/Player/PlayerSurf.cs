using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSurf : MonoBehaviour
{
    public float SURF_DELAY = 0.4f;
    float surfDelay = 0.4f;
    public bool isSurf = false;
    public float power = 100f;
    public int manaUsed = 5;

    public Animator anim;
    public Collider2D trigger;
    public Player player;

    private SoundManager soundManager;
    // Start is called before the first frame update
    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && !isSurf && player.isGround && player.currentMana >= manaUsed )
        {
            isSurf = true;
            surfDelay = SURF_DELAY;
            trigger.enabled = true;
            player.UseMana(manaUsed);

            soundManager.PlaySound("hey"); // this changed
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
                trigger.enabled = false;
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
