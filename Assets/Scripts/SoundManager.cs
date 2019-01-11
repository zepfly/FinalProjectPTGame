using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioClip coin, sword, crash;

    //this changed 
    private AudioClip eat,drink,life;
    private AudioClip huh, hah, hey, run, hurted;
    // End

    public AudioSource audioSource;

    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coin = Resources.Load<AudioClip>("GameCoin");
        sword = Resources.Load<AudioClip>("Sword");
        crash = Resources.Load<AudioClip>("RockCrash");
        eat = Resources.Load<AudioClip>("Eat");
        drink = Resources.Load<AudioClip>("Drink");
        huh = Resources.Load<AudioClip>("Huh");
        hah = Resources.Load<AudioClip>("Hah");
        hey = Resources.Load<AudioClip>("Hey");
        run = Resources.Load<AudioClip>("Run");

        hurted = Resources.Load<AudioClip>("Hurted");
        life = Resources.Load<AudioClip>("Life");

    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "coin":
                audioSource.clip = coin;
                audioSource.PlayOneShot(coin, 0.5f);
                break;

            case "sword":
                audioSource.clip = sword;
                audioSource.PlayOneShot(sword, 0.5f);
                break;

            case "crash":
                audioSource.clip = crash;
                audioSource.PlayOneShot(crash, 0.5f);
                break;
                //This changed
            case "eat":
                audioSource.clip = eat;
                audioSource.PlayOneShot(eat, 0.5f);
                break;

            case "drink":
                audioSource.clip = drink;
                audioSource.PlayOneShot(drink, 0.5f);
                break;
            case "huh":
                audioSource.clip = huh;
                audioSource.PlayOneShot(huh, 0.5f);
                break;
            case "hah":
                audioSource.clip = hah;
                audioSource.PlayOneShot(hah, 0.5f);
                break;
            case "hey":
                audioSource.clip = hey;
                audioSource.PlayOneShot(hey, 0.5f);
                break;
            case "run":
                audioSource.clip = run;
                audioSource.PlayOneShot(run, 0.5f);
                break;
            case "life":
                audioSource.clip = life;
                audioSource.PlayOneShot(life, 0.5f);
                break;
            case "hurted":

                audioSource.clip = hurted;
                audioSource.PlayOneShot(hurted, 0.5f);
                break;
            //End
            default:
                break;
        }
    }
}
