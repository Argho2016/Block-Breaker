using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    //Configuration parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int PointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText; 

    //State variable
    [SerializeField] int CurrentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            //Use this everytime Singleton is used
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = CurrentScore.ToString(); 
    }

    // Update is called once per frame
    void Update () {

        Time.timeScale = gameSpeed;
	}

    public void AddToScore()
    {
        //CurrentScore = CurrentScore + PointsPerBlockDestroyed;
        CurrentScore += PointsPerBlockDestroyed;
        scoreText.text = CurrentScore.ToString();
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }
}
