using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Animator anim;
    public GameMaster gameMaster;

    public const float MAX_SPEED = 3f;
    public const float MAX_HIGH = 5f;
    public float speed = 50f, jumpPow = 320f;
    public bool isGround = false, isFaceRight = true, canDoubleJump = false;

    private const int MAX_HEALTH = 5;
    private int currentHealth;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        currentHealth = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rigid.velocity.x));
        anim.SetBool("IsGround", isGround);

        // handling event jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGround)
            {
                isGround = false;
                canDoubleJump = true;
                rigid.AddForce(Vector2.up * jumpPow);
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rigid.AddForce(Vector2.up * jumpPow * 0.9f);
            }
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rigid.AddForce(Vector2.right * speed * h);

        // handling player's speed and high velocity
        if (rigid.velocity.x >= MAX_SPEED)
            rigid.velocity = new Vector2(MAX_SPEED, rigid.velocity.y);
        if (rigid.velocity.x <= -MAX_SPEED)
            rigid.velocity = new Vector2(-MAX_SPEED, rigid.velocity.y);

        if (rigid.velocity.y >= MAX_HIGH)
            rigid.velocity = new Vector2(rigid.velocity.x, MAX_HIGH);
        if (rigid.velocity.y <= -MAX_HIGH)
            rigid.velocity = new Vector2(rigid.velocity.x, -MAX_HIGH);

        // handling player's face when move left or right
        if (h > 0 && !isFaceRight)
            Flip();
        if (h < 0 && isFaceRight)
            Flip();

        // handling friction for player
        if (isGround)
        {
            rigid.velocity = new Vector2(rigid.velocity.x * 0.9f, rigid.velocity.y);
        }
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Flip()
    {
        isFaceRight = !isFaceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (gameMaster.Score > PlayerPrefs.GetInt("highScore"))
            PlayerPrefs.SetInt("highScore", gameMaster.Score);
    }
    public void KnockBack(float knockPow, Vector2 knockDir)
    {
        rigid.velocity = new Vector2(0, 0);

        if (isFaceRight)
            rigid.AddForce(new Vector2(Mathf.Abs(knockDir.x) * -100, Mathf.Abs(knockDir.y) * knockPow));
        else
            rigid.AddForce(new Vector2(Mathf.Abs(knockDir.x) * 100, Mathf.Abs(knockDir.y) * knockPow));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            gameMaster.Score += 1;
        }
    }
}
