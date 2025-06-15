
using UnityEngine;
using UnityEngine.UI;


public class DifficultyController : MonoBehaviour
{
    // get reference to game controller script
    private GameController gameControllerScript;


    // get reference to UI button
    private Button button;


    // game difficulty
    public int difficultyLevel;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to game controller script
        gameControllerScript = GameObject.Find("Game Controller").GetComponent<GameController>();

        // set reference to UI button
        button = GetComponent<Button>();

        // listen for button click event
        ListenForButtonClickEvent();
    }


    private void ListenForButtonClickEvent()
    {
        // if a difficulty button is pressed, call the set difficulty function
        button.onClick.AddListener(SetDifficulty);
    }


    private void SetDifficulty()
    {
        // set the difficulty of the game
        gameControllerScript.targetSpawnRate /= difficultyLevel;

        // close the options screen
        gameControllerScript.optionsScreen.SetActive(false);

        // start playing the game
        gameControllerScript.RestartGame();
    }


} // end of class
