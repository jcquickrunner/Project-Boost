using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // accessing this script

    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    // on start your initializing it so you have acess to all these methods within the game status script
    public void playLeyScene()
    {
        SceneManager.LoadScene("PlayScene 2");
    }
    public void playFirstLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void story(){
        SceneManager.LoadScene("Story");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("NextLevel");
        }
    }
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadNextScene();
        }
    }   -------this works-----*/


}