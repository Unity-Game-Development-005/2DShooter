
using UnityEngine;


public class Target : MonoBehaviour
{
    // get a reference to the target rigidbody component
    private Rigidbody targetRb;


    // minimum target speed
    private float minTargetSpeed = 12f;

    // maximum target speed
    private float maxTargetSpeed = 16f;

    // minimum target torque
    private float minTargetTorque = -10f;

    // maximum target torque
    private float maxTargetTorque = 10f;

    // target minimum spawn position x
    private float minTargetSpawnRangeX = -4f;

    // target maximum spawn position x
    private float maxTargetSpawnRangeX = 4f;

    // target spawn position y
    private float targetSpawnPosY = -6;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to the target rigidbody
        targetRb = GetComponent<Rigidbody>();

        // spawn a new target
        NewTarget();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    private void NewTarget()
    {
        InitialiseTarget();

        SpawnTarget();
    }


    private void InitialiseTarget()
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


    // if the player clicks on a target
    private void OnMouseDown()
    {   
        // destroy the target
        Destroy(gameObject);
    }


    // if a target collides with the sensor
    private void OnTriggerEnter(Collider collidingObject)
    {
        // destroy the target
        Destroy(gameObject);
    }


} // end of class
