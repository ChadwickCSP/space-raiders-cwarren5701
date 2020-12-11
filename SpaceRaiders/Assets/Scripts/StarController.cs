using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    //determines the speed of the star
    public float speed;

    //determines the y bounds for stars 
    public float minY, maxY;

    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveStar();

        //assigning y to the y value of the star's position
        float y = transform.position.y;

        //if star goes above maxY then
        if (y > maxY)
        {
            //destroy object that this script is attached to
            UnityEngine.Object.Destroy(this.gameObject);
        }

        //if star goes above maxY then
        if (y < minY)
        {
            //destroy object that this script is attached to
            UnityEngine.Object.Destroy(this.gameObject);
        }

    }

    void moveStar()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
    }

   
}

    

