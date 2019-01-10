using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Player player;

    public Sprite[] HeartSprites;

    public Image imgHeart;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.CurrentHealth > 5)
        //    player.CurrentHealth = 5;

        //if (player.CurrentHealth < 0)
        //    player.CurrentHealth = 0;

        imgHeart.sprite = HeartSprites[0];
    }
}
