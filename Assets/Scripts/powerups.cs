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
    enum State { collission, noCollission };
    // Start is called before the first frame update
    State state2 = State.collission;
    BoxCollider collision;
    void Start()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        switch (collision.gameObject.tag)
        {
            case "player":
                HandleHit();
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                break;

        }
    }
    public void HandleInput() {
        state2 = State.noCollission;
        GetComponent<BoxCollider>().isTrigger = true;



    }
    private void NextLevel()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            HandleInput();
        }
    }

    private void HandleHit()
    {
        if (state2 == State.collission)
        {
            TriggerParticleVFX();
            Destroy(gameObject);


            gameStatus.AddToScore();
        }
        
    }
    private void TriggerParticleVFX()
    {
        GameObject sparkles = Instantiate(powerUPFx, transform.position, transform.rotation);
        UnityEngine.Object.Destroy(sparkles, 1f);
    }







    public void DestroyPowerUp()
    {
        
        Destroy(gameObject);
       
        
        gameStatus.addToScore();
       
    }
    // Update is called once per frame
    void Update()
    {
        NextLevel();
        gameStatus.renderScoreOnScreen();
    }
}
