
using UnityEngine;


public class Target : MonoBehaviour
{
    // get a reference to the game controller script
    private GameController gameController;

    // get a reference to the target rigidbody component
    private Rigidbody targetRb;


    // target parameters
    // minimum target speed
    private float minTargetSpeed;

    // maximum target speed
    private float maxTargetSpeed;

    // minimum target torque
    private float minTargetTorque;

    // maximum target torque
    private float maxTargetTorque;

    // target minimum spawn position x
    private float minTargetSpawnRangeX;

    // target maximum spawn position x
    private float maxTargetSpawnRangeX;

    // target spawn position y
    private float targetSpawnPosY;

    // target points
    public int targetPoints;


    // particle effect to show on destroying target
    public ParticleSystem explosionParticle;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to game controller script
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();

        // set reference to the target rigidbody
        targetRb = GetComponent<Rigidbody>();

        // initialise target parameters
        InitialiseTargetParameters();

        // spawn a new target
        NewTarget();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    private void InitialiseTargetParameters()
    {
        // minimum target speed
        minTargetSpeed = 12f;

        // maximum target speed
        maxTargetSpeed = 16f;

        // minimum target torque
        minTargetTorque = -10f;

        // maximum target torque
        maxTargetTorque = 10f;

        // target minimum spawn position x
        minTargetSpawnRangeX = -4f;

        // target maximum spawn position x
        maxTargetSpawnRangeX = 4f;

        // target spawn position y
        targetSpawnPosY = -6;
    }


private void NewTarget()
    {
        SetTargetParameters();

        SpawnTarget();
    }


    private void SetTargetParameters()
    {
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }


    private void SpawnTarget()
    {
        transform.position = RandomSpawnPosition();
    }


    private Vector3 RandomForce()
    {
        // return a random target speed
        return Vector3.up * Random.Range(minTargetSpeed, maxTargetSpeed);
    }


    private float RandomTorque()
    {
        // return a random target torque
        return Random.Range(minTargetTorque, maxTargetTorque);
    }


    private Vector3 RandomSpawnPosition()
    {
        // return a random target spawm position
        return new Vector3(Random.Range(minTargetSpawnRangeX, maxTargetSpawnRangeX), targetSpawnPosY);
    }


    private void UpdateScore()
    {
        // increase player's score
        gameController.score += targetPoints;

        // update the ui
        gameController.Score();
    }


    private void UpdateLives()
    {
        // decrease player's lives
        gameController.lives--;

        // update the ui
        gameController.Lives();
    }


    // if the player clicks on a target
    private void OnMouseDown()
    {
        // if the game is running
        if (gameController.gameIsActive)
        {
            // and the target is a good target
            if (gameObject.CompareTag("Good"))
            {
                UpdateScore();
            }

            // but if the target is a bad target
            if (gameObject.CompareTag("Bad"))
            {
                UpdateLives();
            }

            // destroy the target
            Destroy(gameObject);

            // show a particle effect
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            // see if we have any lives left
            if (gameController.lives == 0)
            {
                // if we don't, then display the game over screen
                gameController.GameOver();
            }
        }
    }


    // if a target collides with the sensor
    private void OnTriggerEnter(Collider collidingObject)
    {
        // destroy the target
        Destroy(gameObject);
    }


} // end of class
