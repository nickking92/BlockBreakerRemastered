
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {
    [Range(0.1f,10f)][SerializeField] float gameSpeed=1f;
    [SerializeField] int pointsPerBlockDestroyed = 99;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int currentScore=0;
    [SerializeField] bool isAutoPlayEnabled;


    void Awake()
    {
      
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
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


    void Start()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        string sc = currentScene.name;
        scoreText.text = currentScore.ToString();
        if (sc == "MainMenu")
        {
            scoreText.enabled = false;
        }
    }
    // Update is called once per frame
    void Update () {
        Time.timeScale =gameSpeed;
        scoreText.text = currentScore.ToString();
    }

    public void AddScore()
    {
        currentScore +=pointsPerBlockDestroyed;
        
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
