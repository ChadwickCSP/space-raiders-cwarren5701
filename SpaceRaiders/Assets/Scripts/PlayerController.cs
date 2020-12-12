using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variable of the float class
    public float speed;

    //controls bounds for the x axis 
    public float maxX, minX;

    //controls bounds for the y axis 
    public float maxY, minY;

    public bool indestructable;

    //the Laser GameObject to clone when firing
    public GameObject laser;

    //the enemy ship that will be colliding with player 
    public EnemyController enemyShip;

    public EnemyController enemyLaser;

    public GameObject respawnedPlayerShip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when update method occurs, it with run movePlayer method as well
        movePlayer();

        //when update method occurs, it with run handleFire method as well
        handleFire();
    }

    private void handleFire()
    {
        //assigns variable to output of checking to see if space bar is pressed(will give a true or false value back)
        bool isFiring = Input.GetKeyDown(KeyCode.Space);


        if(isFiring)
        {
        print("Fire!");

            //create a copy of the laser object which copies all of the values that are associated with it(e.g.speed)
            GameObject newLaser = UnityEngine.Object.Instantiate(laser);

            //new variables for newLaser's x and y values 
            float x, y;

            //x position will be equal to the ship's
            x = transform.position.x;

            //y postion will be +0.5 because we want it to spawn right in front of the ship. It's 0.5f because you need to tell Unity that this number is a floating value(decimal)
            y = transform.position.y + 0.5f;

            //setting the newLaser's position equal to the x and y values specified above
            newLaser.transform.position = new Vector2(x, y);

            

            // assigning "laserController" to the script LaserController that's in that object(laser)
            LaserController laserController = newLaser.GetComponent<LaserController>();
            laserController.speed = 6;
        }
    }

    void movePlayer()
        {
            //new variable assigning "playerInput" to keyboard input for horizontal axis
            float playerInput = Input.GetAxis("Horizontal");

            //new variable assigning "playerYInput" to keyboard input for vertical axis
            float playerYInput = Input.GetAxis("Vertical");

            //move object right based on the speed and if player is pressing keys
            transform.Translate(Vector3.right * speed * Time.deltaTime * playerInput);

            //move object right based on the speed and if player is pressing keys
            transform.Translate(Vector3.up * speed * Time.deltaTime * playerYInput);

            //assigning "x" to the value of the objects x postion 
            float x = transform.position.x;

            //assigning "Y" to the value of the objects Y postion 
            float y = transform.position.y;

            //if y value is less than minY
            if (y < minY)
            {
                //prints message 
                print("BEYOND BOTTOM SIDE!");

                //when the object goes past the minY it is moved back to the minY, so basically it cannot go any further than the minY, and x value is staying the same 
                transform.position = new Vector3(x, minY);
            }

            //if y value is greater than maxY
            if (y > maxY)
            {
                //prints message
                print("BEYOND TOP SIDE!");

                //when the object goes past the maxY it is moved back to the maxY, so basically it cannot go any further than the maxY, and x value is staying the same 
                transform.position = new Vector3(x, maxY);
            }

            //if x value is less than minX
            if (x < minX)
            {
                //prints message 
                print("BEYOND LEFT SIDE!");

                //when the object goes past the minX it is moved back to the minX, so basically it cannot go any further than the minX, and y value is staying the same 
                transform.position = new Vector3(minX, y);
            }

            //if x value is greater than maxX
            if (x > maxX)
            {
                //prints message
                print("BEYOND RIGHT SIDE!");

                //when the object goes past the maxX it is moved back to the maxX, so basically it cannot go any further than the maxX, and y value is staying the same 
                transform.position = new Vector3(maxX, y);
            }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the enemyController(see variables at top) is attached to object its colling with 
        if(enemyShip || enemyLaser != null)
        {
            if(indestructable == false)
            {
                print("Destroyed!");
                //destroy this object 
                UnityEngine.Object.Destroy(this.gameObject);

                PlayerSpawner playerSpawner = respawnedPlayerShip.GetComponent<PlayerSpawner>();

                playerSpawner.isDead = true;

            }
            

        }
    }

}
