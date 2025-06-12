
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameController : MonoBehaviour
{
    // declare a list of targets
    public List<GameObject> targets;


    // UI
    // game over screen
    public GameObject gameOverScreen;

    // player score text
    public TMP_Text playerScoreText;

    // player hi score text
    public TMP_Text playerHiScoreText;

    // player lives text
    public TMP_Text playerLivesText;

    // game over text
    public TMP_Text gameOverText;


    // the speed at which targets are spawned
    private float targetSpawnRate = 1f;

    // player's score
    public int score;

    // player's hi score
    public int hiScore = 0;

    // player lives
    public int lives;

    // if game is running
    public bool gameIsActive;




    
    void Start()
    {
        // start / restart the game
        RestartGame();
    }


    public void RestartGame()
    {
        // deactive the game over screen
        //gameOverScreen.SetActive(false);

        // the game over screen is deactivated through the
        // button's on-click function in the inspector

        // initialise the game
        InitialiseGame();

        // start spawning some targets
        StartCoroutine(SpawnTarget());
    }


    public void InitialiseGame()
    {
        // update score
        score = 0;

        Score();

        // update lives
        lives = 3;

        Lives();

        // start playing game
        gameIsActive = true;
    }


    private IEnumerator SpawnTarget()
    {
        // while the game is running
        while (gameIsActive)
        {
            // wait before spawning a target
            yield return new WaitForSeconds(targetSpawnRate);

            // select a random target to spawn
            int targetIndex = Random.Range(0, targets.Count);

            // and spawn it
            Instantiate(targets[targetIndex]);
        }
    }


    public void Score()
    {
        //score++;

        //Debug.Log("SCORE: " + score);

        playerScoreText.text = score.ToString();
    }


    public void Lives()
    {
        //score++;

        //Debug.Log("SCORE: " + score);

        playerLivesText.text = lives.ToString();
    }


    // if the player has clicked on a skull
    public void GameOver()
    {
        // display game over
        //Debug.Log("G A M E  O V E R");

        // stop playing game
        gameIsActive = false;

        // display the game over screen
        gameOverScreen.SetActive(true);
    }


} // end of class
