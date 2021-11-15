using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{


    public static GameOver instance;

    [SerializeField]
    private Canvas gameOverCanvas;


    private void Awake()
    {

        if (instance == null)
            instance = this;

    }

    public void GameOverInfo()
    {
        gameOverCanvas.enabled = true;
    }

    public void StartGame()
    {

        SceneManager.LoadScene("Level 1");

    }

    public void RestartGame()
    {

        SceneManager.LoadScene("Intro");

    }


    public void MainMenu()
    {

        SceneManager.LoadScene("Main Menu");

    }


} //class
