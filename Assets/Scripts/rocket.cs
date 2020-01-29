using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocket : MonoBehaviour
{
   
    Rigidbody rigidBody;
    AudioSource thrust;
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] AudioClip mainEngine;//stores audioclip, way to set audi in code
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip transitionToMainMenu;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;
    ScoreLoader gameStatus;
    powerups powerUp;
    // Start is called before the first frame update
    enum State {  alive, dying, changing};
    State state = State.alive;
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
                state = State.dying;
                thrust.Stop();
                mainEngineParticles.Stop();
                thrust.PlayOneShot(explosion);
                deathParticles.Play();
                Invoke("LoadLevel", 2f);//so invoke basically is a way to delay a function but have others continue running without stopping the program.
                break;
            case "Finish":
                state = State.changing;
                thrust.Stop();
                successParticles.Play();
                thrust.PlayOneShot(transitionToMainMenu);
                Invoke("LoadMenu", 2f);
                break;
            case "PowerUp":
                
                

                break;
            default:
                break;


        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(2);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame

    void Update()
    {

        ProcessInput();
    }
    public void LoadMain()
    {
        SceneManager.LoadScene(0);
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
        if (state == State.alive)
        {
            ThrustMovement();
            RocketRotation();
            ThrustSound();
            

        }
       /* if (state != State.alive)
        {
            thrust.Stop();
        } */

    }

    private void ThrustMovement()
    { if (state == State.alive)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                print("space pressed");

                rigidBody.AddRelativeForce(Vector3.up);//relative to postition
                mainEngineParticles.Play();
            }
            else mainEngineParticles.Stop();
            
        }
        

    }
    
    private void RocketRotation()
    {
        
        if (state == State.alive)
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

    }

    private void ThrustSound()
    {
        if (state == State.alive)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (!thrust.isPlaying)
                {
                    thrust.PlayOneShot(mainEngine);
                }

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
     

    
