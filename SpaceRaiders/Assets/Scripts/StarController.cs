using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    //determines the speed of the star
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveStar();
    }

    void moveStar()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
    }
}

    

