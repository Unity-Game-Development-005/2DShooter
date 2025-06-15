
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameController : MonoBehaviour
{
    // declare a list of targets
    public List<GameObject> targets;


    // UI
    // title screen
    public GameObject titleScreen;

    // difficulty screen
    public GameObject optionsScreen;

    // pawz screen
    public GameObject pawzScreen;

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
    public float targetSpawnRate;

    // player's score
    public int score;

    // player's hi score
    public int hiScore = 0;

    // player lives
    public int lives;

    // if game is running
    //public bool gameIsActive;
    public bool gameOver;

    // are we playing the game
    public bool gamePawzed;

    // is the game in play
    public bool inPlay;





    void Start()
    {
        LoadTitleScreen();
    }



    private void Update()
    {
        // if the game is in play
        if (inPlay)
        {
            // and the game is not already pawzed
            if (!gamePawzed)
            {
                // and the player has pressed the escape key
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PawzGame();
                }
            }
        }
    }


    private void PawzGame()
    {
        // pawz the game
        gamePawzed = true;

        // load the pawz screen
        pawzScreen.SetActive(true);

        // and freeze game play
        Time.timeScale = 0f;
    }


    public void ResumeGame()
    {
        // un-pawz the game
        gamePawzed = false;

        // close the pawz screen
        pawzScreen.SetActive(false);

        // and un-freeze game play
        Time.timeScale = 1f;
    }


    public void LoadTitleScreen()
    {
        // if the back button is pressed from the options screen
        // then close the options screen
        optionsScreen.SetActive(false);

        // load the title screen
        titleScreen.gameObject.SetActive(true);
    }


    // when the play button is pressed
    public void SelectDifficulty()
    {
        // close the title screen
        titleScreen.SetActive(false);

        // close the game over screen
        gameOverScreen.SetActive(false);

        // load the difficulty screen
        optionsScreen.SetActive(true);
    }


    public void RestartGame()
    {
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

        // the speed at which targets are spawned
        targetSpawnRate = 1f;

        // start playing game
        gameOver = false;

        // game is in play
        inPlay = true;
    }


    private IEnumerator SpawnTarget()
    {
        // while the game is running
        while (inPlay)
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
        playerScoreText.text = score.ToString();
    }
    

    private void UpdateHiScore()
    {
        // if the score is greater than the hiscore
        if (score > hiScore)
        {
            // update the hi score
            hiScore = score;

            playerHiScoreText.text = hiScore.ToString();
        }
    }


    public void Lives()
    {
        playerLivesText.text = lives.ToString();
    }


    // if the player has clicked on a skull
    public void GameOver()
    {
        // stop playing game
        gameOver = true;

        inPlay = false;

        // update the hi score
        UpdateHiScore();

        // display the game over screen
        gameOverScreen.SetActive(true);
    }


} // end of class
