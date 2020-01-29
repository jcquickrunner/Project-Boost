using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int powerUps;
    // Start is called before the first frame update

    SceneLoader ScoreLoader;//Cache so you can acess sceneloader script and names it scene loader
    public void CountBreakableBlocks()
    {
        powerUps++;// every block has this script and each one runs this method once therefor counting the number of blocks and adding 1 to the interger tyoe varibale breakableBlocks
    }
    private void Start()
    {
        ScoreLoader = FindObjectOfType<SceneLoader>();
    }
    public void BlockDestroyed()
    {
        powerUps--;
       
    }







}