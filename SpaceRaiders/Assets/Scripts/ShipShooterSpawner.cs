using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooterSpawner : MonoBehaviour
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

        //if the duration of time since the last spawn is greater than the spawn rate then...
        if (elapsedTime > spawnRate)
        {


            //spawning new enemy and calling it "newEnemy"
            GameObject newEjectedShip = UnityEngine.Object.Instantiate(enemy);

            //setting the position of the newEnemy to 7, 2 
            newEjectedShip.transform.position = new Vector2(7, 2);

            //get the ShipShooterController script 
            ShipShooterController ShipShooterController = newEjectedShip.GetComponent<ShipShooterController>();

            //set the speed of the enemy 
            ShipShooterController.speedX = -5;

            //set the speed of the enemy 
            ShipShooterController.speedY = -2;

            //set indestructable to false
            ShipShooterController.indestructable = false;

            //set the last time it was spawned equal to the current time
            lastSpawnTime = currentTime;




        }
    }
}
