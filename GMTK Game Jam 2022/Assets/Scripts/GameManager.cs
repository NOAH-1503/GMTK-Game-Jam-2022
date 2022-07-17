using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ScoreText scoreText;

    public PlayerMovement playerMovement;

    public GameObject ladderButton;

    public void ClimbLadder()
    {
        scoreText.UpdateHighScore();
        Invoke("RestartScene", 1f);
    }

    public void GameOver()
    {
        Invoke("RestartScene", 1f);
    }

    void Update()
    {
        if (playerMovement.isJumping == true)
        {
            ladderButton.SetActive(false);
        }
        else    
        {
            Invoke("EnableLadder", 1f);
        }
    }

    public void EnableLadder()
    {
        if (ScoreText.score < -10)
        {
            ladderButton.SetActive(true);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
