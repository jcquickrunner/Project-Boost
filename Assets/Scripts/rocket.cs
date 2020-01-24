using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource thrust;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
         thrust = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("space pressed");
            rigidBody.AddRelativeForce(Vector3.up);//relative to postition
            if (!thrust.isPlaying)
            {
                thrust.Play();
            } else
            {
                thrust.Stop();
                
            }
            

        }
        if (Input.GetKey(KeyCode.A))
        {
            print("rotating left");
            transform.Rotate(Vector3.forward);
           
        } else if (Input.GetKey(KeyCode.D))
        {
            print("Rotating Right");
            transform.Rotate(-Vector3.forward);//- vector forward would work here as well

        }

    }
}
