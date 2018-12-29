using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coin, sword, crash;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coin = Resources.Load<AudioClip>("GameCoin");
        sword = Resources.Load<AudioClip>("Sword");
        crash = Resources.Load<AudioClip>("RockCrash");
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

            default:
                break;
        }
    }
}
