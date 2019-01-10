using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int score = 0;
    public int highScore;

    public Text scoreText;
    public Text highScoreText;
    public Text nextLevelText;
    
    public int Score { get => score; set => score = value; }
    public int HighScore { get => highScore; set => highScore = value; }

    // Start is called before the first frame update
    void Start()
    {
        nextLevelText.enabled = false;
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "High score: " + highScore;

        if (PlayerPrefs.HasKey("score"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("score");
                score = 0;
            }
            else
            {
                score = PlayerPrefs.GetInt("score");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;   
    }
}
