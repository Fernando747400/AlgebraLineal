using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private Text playerOneScoreText;
    [SerializeField] private Text playerTwoScoreText;
    [SerializeField] private Text playerOneHighScore;
    [SerializeField] private Text playerTwoHighScore;

    void Start()
    {
        createScore();
    }

 
    void Update()
    {
        displayScores();
    }

    void createScore()
    {
            PlayerPrefs.SetInt("PlayerOneScore", 0);  
            PlayerPrefs.SetInt("PlayerTwoScore", 0);   
        if (!PlayerPrefs.HasKey("PlayerOneHighScore"))
        {
            PlayerPrefs.SetInt("PlayerOneHighScore", 0);         
        }

        if (!PlayerPrefs.HasKey("PlayerTwoHighScore"))
        {
            PlayerPrefs.SetInt("PlayerTwoHighScore", 0);
        }
    }

    void displayScores()
    {
        playerOneScoreText.text = PlayerPrefs.GetInt("PlayerOneScore").ToString();
        playerTwoScoreText.text = PlayerPrefs.GetInt("PlayerTwoScore").ToString();
        playerOneHighScore.text = PlayerPrefs.GetInt("PlayerOneHighScore").ToString();
        playerTwoHighScore.text = PlayerPrefs.GetInt("PlayerTwoHighScore").ToString();
    }
}
