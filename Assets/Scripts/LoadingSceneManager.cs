using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public GameObject loadingScreenObj;
    public Slider slider;
    public Text txtProgress;

    AsyncOperation async;

    public void LoadScene(string strScene)
    {
        StartCoroutine(LoadingSlider(strScene));
    }

    IEnumerator LoadingSlider(string strScene)
    {
        async = SceneManager.LoadSceneAsync(strScene);
        loadingScreenObj.SetActive(true);
        async.allowSceneActivation = false;
        Time.timeScale = 0.2f;

        while (!async.isDone)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            txtProgress.text = slider.value * 100f + "%";
            yield return null;
        }
    }
}
