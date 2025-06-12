
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    // declare a list of targets
    public List<GameObject> targets;


    private float targetSpawnRate = 1f;

    private int numberOfTargets = 10;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }


    // Update is called once per frame
    void Update()
    {

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


} // end of class
