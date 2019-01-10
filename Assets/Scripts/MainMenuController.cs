using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Setting()
    {
        SceneManager.LoadScene("Options");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
