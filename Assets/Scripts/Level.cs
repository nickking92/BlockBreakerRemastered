using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    [SerializeField] int breakableBlocks;
    SceneLoader sceneloader;

    // Use this for initialization
    void Start()
    {
         sceneloader = GetComponent<SceneLoader>();
    }
    public void CountBreakableBlocks()
    {
       
        breakableBlocks++;
    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();

            //SceneManager.LoadScene("Game over");

        }
    }
}
