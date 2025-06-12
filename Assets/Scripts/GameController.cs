
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameController : MonoBehaviour
{
    // declare a list of targets
    public List<GameObject> targets;


    // UI
    // player score
    public TMP_Text playerScore;

    // player hi score
    public TMP_Text playerHiScore;

    // player lives
    public TMP_Text playerLives;


    // the speed at which targets are spawned
    private float targetSpawnRate = 1f;

    // the number of targets to spawn
    private int numberOfTargets = 50;

    // player's score
    public int score = 0;

    // player's hi score
    public int hiScore = 0;

    // player lives
    public int lives = 3;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialiseGame();

        StartCoroutine(SpawnTarget());
    }


    // Update is called once per frame
    void Update()
    {
      
    }


    public void InitialiseGame()
    {
        Score();

        Lives();
    }


    private IEnumerator SpawnTarget()
    {
        while (numberOfTargets > 0)
        {
            yield return new WaitForSeconds(targetSpawnRate);

            int targetIndex = Random.Range(0, targets.Count);

            Instantiate(targets[targetIndex]);

            numberOfTargets--;
        }
    }


    public void Score()
    {
        //score++;

        //Debug.Log("SCORE: " + score);

        playerScore.text = score.ToString();
    }


    public void Lives()
    {
        //score++;

        //Debug.Log("SCORE: " + score);

        playerLives.text = lives.ToString();
    }


    // if the player has clicked on a skull
    public void GameOver()
    {
        // display game over
        Debug.Log("G A M E  O V E R");
    }


} // end of class
