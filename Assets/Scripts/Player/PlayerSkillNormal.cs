using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillNormal : MonoBehaviour
{
    public float SKILL_DELAY = 0.5f;
    float skillDelay;
    public bool isSkillNormal = false;
    public float speedSkill = 40f;
    public int manaUsed = 2;

    public Animator anim;
    public Player player;
    public GameObject skillNormalMagic;

    private SoundManager soundManager; // This changed


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();// this changed
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !isSkillNormal && player.currentMana >= manaUsed  /*&& player.isGround && Mathf.Abs(player.rigid.velocity.x) < 0.1f*/)
        {
            Debug.Log("Skill Normal");
            isSkillNormal = true;
            skillDelay = SKILL_DELAY;
            player.UseMana(manaUsed);
            Invoke("SkillNormal", 0.2f);
            soundManager.PlaySound("huh"); // this changed
        }

        if (isSkillNormal)
        {
            if (skillDelay > 0)
            {
                skillDelay -= Time.deltaTime;
            }
            else
            {
                isSkillNormal = false;
            }
        }

        anim.SetBool("IsSkillNormal", isSkillNormal);
    }

    void SkillNormal()
    {
        float xOffset = (player.isFaceRight) ? 1f : -1f;
        Vector3 position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + 0.2f, player.transform.position.z);
        GameObject skillNormalMagicClone = Instantiate(skillNormalMagic, position, Quaternion.identity) as GameObject;
        Vector3 direction = (player.isFaceRight) ? Vector3.right : Vector3.left;
        skillNormalMagicClone.GetComponent<Rigidbody2D>().velocity = direction * speedSkill;
        Destroy(skillNormalMagicClone, 2f);
    }
}
