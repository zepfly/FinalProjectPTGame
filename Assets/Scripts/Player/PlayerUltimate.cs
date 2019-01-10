using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimate : MonoBehaviour
{
    public float ULTIMATE_DELAY = 0.8f;
    public float timeToUltimate = 0.2f;
    float ultimateDelay;
    public bool isUltimate = false;
    public float speedUltimate = 5f;
    public int manaUsed = 20;

    public Animator anim;
    public Player player;
    public GameObject ultimateMagic;

    private SoundManager soundManager;// this changed

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent < SoundManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isUltimate && player.currentMana >= manaUsed  /*&& player.isGround && Mathf.Abs(player.rigid.velocity.x) < 0.1f*/)
        {
            Debug.Log("Ultimate");
            isUltimate = true;
            ultimateDelay = ULTIMATE_DELAY;
            player.UseMana(manaUsed);
            Invoke("Ultimate", timeToUltimate);
            soundManager.PlaySound("hah"); // this changed
        }

        if (isUltimate)
        {
            if (ultimateDelay > 0)
            {
                ultimateDelay -= Time.deltaTime;
            }
            else
            {
                isUltimate = false;
            }
        }

        anim.SetBool("IsUltimate", isUltimate);
    }

    void Ultimate()
    {
        float xOffset = (player.isFaceRight) ? 1f : -1f;
        Vector3 position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + 0.2f, player.transform.position.z);
        GameObject skillNormalMagicClone = Instantiate(ultimateMagic, position, Quaternion.identity) as GameObject;
        Vector3 direction = (player.isFaceRight) ? Vector3.right : Vector3.left;
        skillNormalMagicClone.GetComponent<Rigidbody2D>().velocity = direction * speedUltimate;
        Destroy(skillNormalMagicClone, 2f);
        //yield return null;
    }
}
