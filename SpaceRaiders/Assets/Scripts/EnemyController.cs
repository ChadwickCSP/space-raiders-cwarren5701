using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
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
}
