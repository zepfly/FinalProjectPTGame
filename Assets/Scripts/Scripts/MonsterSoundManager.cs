using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip hurted;
    public AudioClip died;


    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "hurted":
                audioSource.clip = hurted;
                audioSource.PlayOneShot(hurted, 0.5f);
                break;

            case "died":
                audioSource.clip = died;
                audioSource.PlayOneShot(died, 0.5f);
                break;
            default:
                break;

        }
    }
}
