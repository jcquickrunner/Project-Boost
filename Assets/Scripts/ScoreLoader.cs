using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLoader : MonoBehaviour
{
    
    [SerializeField] int pointsPerPowerUpCollected = 5;
    [SerializeField] float gameSpeed = 1f;
   [SerializeField] TextMeshProUGUI ScoreText;
    // Start is called before the first frame update

    //state
    [SerializeField] int currentScore = 0;
    private void Awake()//////////singleton effect///////////////
    {
        int gameStatusCount = FindObjectsOfType<ScoreLoader>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {
        renderScoreOnScreen();
    }

    // Update is called once per frame

    public void addToScore() {
        currentScore++;
        print(currentScore);
    }
    public void destroySelf()

    {
        
        Destroy(gameObject);
    }
    public void renderScoreOnScreen()
    {
        Time.timeScale = gameSpeed;
        ScoreText.GetComponent<TextMeshProUGUI>().text = currentScore.ToString();
    }

    public void AddToScore()
    {
        currentScore = currentScore + pointsPerPowerUpCollected;
    }
}