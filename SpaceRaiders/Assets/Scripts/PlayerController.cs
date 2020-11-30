using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variable of the float class
    public float speed;

    // public variable of the float class for the min and max values in which the object can fly
    public float maxX, minX;

    // public variable of the float class for the min and max values in which the object can fly
    public float maxY, minY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        if(y < minY)
        {
            //prints message 
            print("BEYOND BOTTOM SIDE!");

            //when the object goes past the minY it is moved back to the minY, so basically it cannot go any further than the minY, and x value is staying the same 
            transform.position = new Vector3(x, minY);
        }

        //if y value is greater than maxY
        if(y > maxY)
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

        //print x value 
        print(x);
    }
}
