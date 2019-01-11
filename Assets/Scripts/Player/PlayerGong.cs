using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGong : MonoBehaviour
{
    public float GONG_DELAY = 0.5f;
    float gongDelay;
    public bool isGong = false;
    public int manaUsed = 5;

    public Animator anim;
    public Player player;
    public GameObject gongMagic;
    private SoundManager soundManager; // This changed
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isGong && player.isGround && Mathf.Abs(player.rigid.velocity.x) < 0.1f && player.currentMana >= manaUsed)
        {
            Debug.Log("Gong");
            isGong = true;
            gongDelay = GONG_DELAY;
            player.UseMana(manaUsed);
            Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);
            GameObject gongMagicClone = Instantiate(gongMagic, position, Quaternion.identity) as GameObject;
            Destroy(gongMagicClone, gongDelay);
            soundManager.PlaySound("huh");
        }

        if (isGong)
        {
            if (gongDelay > 0)
            {
                gongDelay -= Time.deltaTime;
            }
            else
            {
                isGong = false;
            }
        }

        anim.SetBool("IsGong", isGong);
    }
}
