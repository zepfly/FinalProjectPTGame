using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioClip coin, sword, crash;

    //this changed 
    public AudioClip eat,drink;
    private AudioClip huh, hah, hey, run;
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
                audioSource.clip = drink;
                audioSource.PlayOneShot(huh, 0.5f);
                break;
            case "hah":
                audioSource.clip = drink;
                audioSource.PlayOneShot(hah, 0.5f);
                break;
            case "hey":
                audioSource.clip = drink;
                audioSource.PlayOneShot(hey, 0.5f);
                break;
            case "run":
                audioSource.clip = drink;
                audioSource.PlayOneShot(run, 0.5f);
                break;
            //End
            default:
                break;
        }
    }
}
