using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //This is the laser to spawn
    public EnemyController laser;

    //this is the speed at which lasers will be fired
    public float fireRate;

    //This is the last time a laser was fired
    public float lastShot;

    //This is the speed of the laser that the enemy fires
    public float laserSpeed;

    //controls bounds for the x axis 
    public float speedX, speedY;

    //controls bounds for the y axis 
    public float minX, maxX;

    // public variable of the float class for the min and max values in which the object can fly
    public float minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when update method occurs, it with run moveEnemy method as well
        moveEnemy();

        //when update method occurs, it with run checkFireLaser method as well
        checkFireLaser();
    }

    void moveEnemy()
    {
        //updates enemys position based on the speed moving on the x and y axis and making usre the object is a contant rate regardless of frames per sec 
        transform.Translate(new Vector2(speedX, speedY) * Time.deltaTime);

        //assigning y to the enemy's position on the x axis 
        float x = transform.position.x;

        //assigning y to the enemy's position on the y axis 
        float y = transform.position.y;

        //"||" are just saying "or"
        //Checks if the ship is out of bounds, if it is it destroys itself 
        if (x < minX || x > maxX || y < minY || y > maxY)
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    //method for code to execute when a specific collision occurs 
    private void OnTriggerEnter2D(Collider2D collision)
    {


        //This is the object that collided with the Enemy
        GameObject otherObject = collision.gameObject;

        //assigning "laserController" to the object with LaserController attached to the other.Object
        //then on that other object we are accessing the LaserController script
        LaserController laserController = otherObject.GetComponent<LaserController>();

        //laserController is attached the object on collision then...
        if (laserController != null)
        {

            //destroying the object that this script is attached to
            UnityEngine.Object.Destroy(this.gameObject);

            //destroying the otherObject which in this case is the laser 
            UnityEngine.Object.Destroy(otherObject);
        }


    }

    void checkFireLaser()
    {

        
        //when the next shot should be fired is equal to a combination of fireRate and the time of the last shot 
        float nextShot = fireRate + lastShot;

        //determining the current time of the game 
        float currentTime = Time.time;
        

        //if laserController is attached and if the nextShot is less than the current time
        if (laser != null && nextShot < currentTime)
        {
            //create a copy of the laser object which copies all of the values that are associated with it(e.g.speed)
            EnemyController enemyLaser = UnityEngine.Object.Instantiate(laser);

            //set Laser's speedY to 3 because when we clone the object all values are set to 0
            enemyLaser.speedY = 3;

            //new variables for newLaser's x and y values 
            float x, y;

            //x position will be equal to the ship's
            x = transform.position.x;

            //y postion will be -0.5 because we want it to spawn right in front of the ship. It's 0.5f because you need to tell Unity that this number is a floating value(decimal)
            y = transform.position.y - 0.5f;

            //setting the newLaser's position equal to the x and y values specified above
            enemyLaser.transform.position = new Vector2(x, y);

            //update lastShot to the currentTime
            lastShot = currentTime;
        }

    }
}
