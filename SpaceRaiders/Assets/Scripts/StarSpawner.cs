using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{

    // The starting Y position of the background starts spawning
    public float startY;
    // Specifies the range of spawning locations for stars
    public float minX, maxX;
    // Specifies the min and max size of the stars to be spawned
    public float minScale, maxScale;
    // Specifies the min and max speed of the stars being spawned
    public float minSpeed, maxSpeed;
    // Specifies the rate at which stars spawn
    public double spawnRate;

    // The star to spawn
    public GameObject star;

    

    // The last time a star was spawned
    private float lastSpawn;

    void Start()
    {
        //setting the last time object was spawned to the actual time in the game 
        lastSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //run this method 
        checkSpawn();
    }
    void checkSpawn()
    {
        // Get the current time
        float currentTime = Time.time;

        // Check how much time has passed since the last spawn
        float timeSinceLastSpawn = currentTime - lastSpawn;

        // If the time is greater than the spawnRate, spawn an enemy!
        if (timeSinceLastSpawn > spawnRate)
        {
            // Create a new star object
            GameObject newStar = UnityEngine.Object.Instantiate(star);

            //setting the location of the object to a random x value range 
            float startX = Random.Range(minX, maxX);

            //setting the scale to a random possible range of values 
            float scale = Random.Range(minScale, maxScale);

            // Set the stars starting position
            newStar.transform.position = new Vector3(startX, startY, 2);

            //set the object to its randomized scale 
            newStar.transform.localScale = new Vector2(scale, scale);

            // Get the StarController
            StarController starController = newStar.GetComponent<StarController>();

            // Set the enemy speed
            float speed = Random.Range(minSpeed, maxSpeed);

            //setting speed to the speed set in the script 
            starController.speed = speed;

            // Reset the timer!
            lastSpawn = currentTime;

            //move star to the randomly assigned newStar position
            starController.transform.position = newStar.transform.position;

            //setting the scale to the random range of values 
            starController.scale = Random.Range(minScale, maxScale);
            // how frequently they spawn
        }
    }
}
