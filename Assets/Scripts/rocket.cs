﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocket : MonoBehaviour
{
   
    Rigidbody rigidBody;
    AudioSource thrust;
    [SerializeField] float rcsThrust = 100f;
    // Start is called before the first frame update
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        thrust = GetComponent<AudioSource>();
         

    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                SceneManager.LoadScene(1);
                break;
            case "Finish":
                SceneManager.LoadScene(2);
                
                break;
            default:
                break;
                
                
        }
    }
    // Update is called once per frame
    
    void Update()
    {
        ProcessInput();
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        Application.Quit();
    }

    private void ProcessInput()
    {
        ThrustMovement();
        RocketRotation();
        ThrustSound();

    }

    private void ThrustMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("space pressed");
            rigidBody.AddRelativeForce(Vector3.up);//relative to postition

        }
    }

    private void RocketRotation()
    {
        rigidBody.freezeRotation = true;
        
        if (Input.GetKey(KeyCode.A))
        {
            print("rotating left");
            float rotationSpeedThisFrame = rcsThrust * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotationSpeedThisFrame);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            float rotationSpeedThisFrame = rcsThrust * Time.deltaTime;
            print("Rotating Right");
            transform.Rotate(-Vector3.forward * rotationSpeedThisFrame);//- vector forward would work here as well

        }
        rigidBody.freezeRotation = !true;
    }

    private void ThrustSound()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!thrust.isPlaying)
            {
                thrust.Play();
            }

        }
        if (Input.GetKeyUp(KeyCode.Space))// so when you stop pressing space the sound stops
        {
            if (thrust.isPlaying)
            {
                thrust.Stop();
            }

        }
    }
}
     

    
