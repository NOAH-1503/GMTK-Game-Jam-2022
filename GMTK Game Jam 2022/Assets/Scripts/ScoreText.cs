using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;
    public static float score;
    public Text highScore;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetFloat("Highscore", 0).ToString("0");
        //Reset();
    }

    // Update is called once per frame
    void Update()
    {
        score = player.transform.position.y;
        scoreText.text = score.ToString("0") + "m";
    }

    public void UpdateHighScore()
    {
        if (score < PlayerPrefs.GetFloat("Highscore", 0))
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "High Score: 0";
    }
}
