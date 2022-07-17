using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ScoreText scoreText;
    public Animator uiAnimator;
    public Animator fadeAnimator;
    public GameObject gameOverUi;
    public Text gameOverText;

    public PlayerMovement playerMovement;
    public Transform playerTransform;

    public GameObject ladderButton;
    public bool ladderClimbable = false;

    public GameObject lBorder;
    public GameObject rBorder;

    public void ClimbLadder()
    {
        scoreText.UpdateHighScore();
        fadeAnimator.SetTrigger("Fade");
        Invoke("RestartScene", 2f);
    }

    public void GameOver()
    {
        fadeAnimator.SetTrigger("Fade");
        gameOverUi.SetActive(true);
        Invoke("RestartScene", 9f);
        if (playerTransform.position.y > -100f)
        {
            gameOverText.text = "Better luck next time...";
        } 
        else if(playerTransform.position.y > -500f)
        {
           gameOverText.text = "Should've climbed when you had the chance...";
        }
        else if (playerTransform.position.y > -1000f)
        {
            gameOverText.text = "Almost made it... Almost.";
        }
        else if (playerTransform.position.y > -5000f)
        {
            gameOverText.text = "Not bad...";
        }
        else
        {
            gameOverText.text = "That must suck...";
        }
    }

    void Update()
    {
        if (playerMovement.isJumping == true)
        {
            ladderClimbable = false;
            ladderButton.SetActive(false);
            uiAnimator.SetTrigger("StartGame");
            uiAnimator.SetBool("TextEnabled", false);
            lBorder.SetActive(false);
            rBorder.SetActive(false);
        }
        else    
        {
            Invoke("EnableLadder", 1f);
        }

        if (Input.GetKey(KeyCode.Escape) && ladderClimbable == true)
        {
            ClimbLadder();
        }
    }

    public void EnableLadder()
    {
        if (ScoreText.score < -10)
        {
            ladderClimbable = true;
            ladderButton.SetActive(true);
            uiAnimator.SetBool("TextEnabled", true);
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
