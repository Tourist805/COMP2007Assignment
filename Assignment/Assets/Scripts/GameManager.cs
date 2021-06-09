using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Start()
    {
        instance = this;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
