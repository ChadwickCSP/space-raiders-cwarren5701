using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    //specifies how fast the laser moves
    public float speed;

    //controls bounds for the y axis 
    public float maxY, minY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //uses the speed and time to more the laser towards the top of the screen 
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        //assigning y to the y value of the laser's position
        float y = transform.position.y;

        //if laser goes above maxY then
        if(y > maxY)
        {
            //destroy object that this script is attached to
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }
}
