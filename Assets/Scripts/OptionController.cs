using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour
{
    public GameObject credits, mainOption;
    public GameObject imgTurnOffMusic, imgTurnOffSfx;

    private void Start()
    {
        credits.SetActive(false);
        mainOption.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MuteMusic()
    {
        imgTurnOffMusic.SetActive(!imgTurnOffMusic.active);
    }
    public void MuteSfx()
    {
        imgTurnOffSfx.SetActive(!imgTurnOffSfx.active);
    }

    public void ToControlScene()
    {
        SceneManager.LoadScene("Controls");
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
        mainOption.SetActive(false);
    }

    public void BackToOption()
    {
        credits.SetActive(false);
        mainOption.SetActive(true);
    }
}
