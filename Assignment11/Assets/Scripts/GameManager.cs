using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Sam Ferstein
 * GameManager.cs
 * Assignment 11
 * This manages the game.
 */

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool isGameActive;
    public GameObject titleScreen;
    public Button restartButton;
    public GameObject gOverScreen;
    public bool isGameLost = false;
    public bool isGameWon = false;
    public GameObject gWinScreen;
    private float timer = 60;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timerText.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive == true)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("f0");
            if (timer <= 0 && isGameLost == false)
            {
                gameWon();
                isGameWon = true;
            }
        }
    }

    public void startGame()
    {
        isGameActive = true;
        isGameLost = false;
        isGameWon = false;
        player.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }

    public void gameOver()
    {
        isGameLost = true;
        gOverScreen.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        isGameActive = false;
    }

    public void gameWon()
    {
        isGameWon = true;
        player.gameObject.SetActive(false);
        gWinScreen.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
