using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int Score = 0;

    public static GameManager Instance = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void AddScore()
    {
        Score += 100;
    }
  
    public void ResetScore()
    {
        Score = 0;
    }

    public int GetScore()
    {
        return Score;
    }

    public void PlayScene()
    {
        SceneManager.LoadScene("Play");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Clickbut(Button but)
    {
        but.gameObject.SetActive(false);
    }
}
