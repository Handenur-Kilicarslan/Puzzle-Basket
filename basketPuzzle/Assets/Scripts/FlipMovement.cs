using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMovement : MonoBehaviour
{
    private Rigidbody myRb;
    public float speed = 50f;

    void Start()
    {
        myRb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            //trasform.Rotate(0, 0, speed * Time.deltaTime);
            myRb.AddForce(Vector3.up * speed);
        }
    }
}
