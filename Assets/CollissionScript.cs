using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollissionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        
    }
}
