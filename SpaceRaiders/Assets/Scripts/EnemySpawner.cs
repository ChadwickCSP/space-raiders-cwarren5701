﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //The number of seconds between enemy spawns 
    public float spawnRate;

    //The time at which the last spawn occured 
    public float lastSpawnTime;

    //This is the enemy to spawn
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        //setting the lastSpawnTime equal to the current time of the current frame  
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // assigning "currentTime" variable to the actual time in the game
        float currentTime = Time.time;

        //The amount of time since hte last spawn occured
        float elapsedTime = currentTime - lastSpawnTime;

        if (elapsedTime > spawnRate)
        {
            //print message
            print("Spawn");

            //spawning new enemy and calling it "newEnemy"
            GameObject newEnemy = UnityEngine.Object.Instantiate(enemy);

            //setting the position of the newEnemy to -10, 5 
            newEnemy.transform.position = new Vector2(-10, 5);

            
            EnemyController EnemyController = newEnemy.GetComponent<EnemyController>();

            //set the speed of the enemy 
            EnemyController.speedX = 5;
            EnemyController.speedY = -2;

            //set the last time it was spawned equal to the current time
            lastSpawnTime = currentTime;

        }
    }
}
