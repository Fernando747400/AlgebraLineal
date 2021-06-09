using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
   public void reloadGame()
    {
        saveData();
        SceneManager.LoadScene("Combat");
    }

    public void closeGame()
    {
        saveData();
        Application.Quit();
    }

    private void saveData()
    {
        if (PlayerPrefs.GetInt("PlayerOneHighScore") < PlayerPrefs.GetInt("PlayerOneScore"))
        {
            PlayerPrefs.SetInt("PlayerOneHighScore", PlayerPrefs.GetInt("PlayerOneScore"));
        }
        if (PlayerPrefs.GetInt("PlayerTwoHighScore") < PlayerPrefs.GetInt("PlayerTwoScore"))
        {
            PlayerPrefs.SetInt("PlayerTwoHighScore", PlayerPrefs.GetInt("PlayerTwoScore"));
        }
        PlayerPrefs.Save();
    }
}
