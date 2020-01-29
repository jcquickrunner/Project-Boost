using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class powerups : MonoBehaviour
{
    [SerializeField] GameObject powerUPFx;
    [SerializeField] AudioClip breakSound;
    [SerializeField]ScoreLoader  gameStatus;
    [SerializeField] TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "player":
                HandleHit();
                
                break;

        }
    }
    private void HandleHit()
    {
        Destroy(gameObject);
        gameStatus.AddToScore();
    }
    
      



    
   

    public void DestroyPowerUp()
    {
        
        Destroy(gameObject);
       
        
        gameStatus.addToScore();
       
    }
    // Update is called once per frame
    void Update()
    {
        gameStatus.renderScoreOnScreen();
    }
}
