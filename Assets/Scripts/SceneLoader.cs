using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

  
 
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        FindObjectOfType<GameStatus>().ResetGame();
      
    }

    public void Exit() 
    {
        Application.Quit();
    
    }
}
