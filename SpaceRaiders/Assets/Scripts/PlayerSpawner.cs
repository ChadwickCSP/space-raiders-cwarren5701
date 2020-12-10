using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    // The player ship to spawn
    public PlayerController toSpawn;

    // The time at which the player will respawn
    public float respawnTime;

    // A boolean that is used to determine if we should spawn a ship
    public bool isDead = false;

    // The starting position of the player ship
    public Vector2 startPosition;

    // Update is called once per frame
    void Update()
    {
        //getting the current time 
        float currentTime = Time.time;

        //if isDead is ture and respawnTime < currentTime then...
        if (isDead && respawnTime < currentTime)
        {
            
            //Spawn the player object
            PlayerController playerController = UnityEngine.Object.Instantiate(toSpawn);

            //update the player position to the start position 
            transform.Translate(startPosition);


            //accessing playercontroller script and Updating it to have the proper speed and bounds
            //PlayerController playerController = respawnedPlayerShip.GetComponent<PlayerController>();
            playerController.speed = 10;
            playerController.minX = -6;
            playerController.maxX = 6;
            playerController.minY = -4.6f;
            playerController.maxY = 4.6f;
            playerController.transform.position = startPosition;

            isDead = false;
        }
    }
}