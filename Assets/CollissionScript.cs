using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollissionScript : MonoBehaviour
{
    ScoreLoader gameStatus;
    powerups powerUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                powerUp.DestroyPowerUp();
                gameStatus.addToScore();
                break;
            
            default:
                break;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
