using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text scoreText;
    public int totalScore;
    public GameObject gameOver;
    public GameObject gameFinished;

    public string nextLevel = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);

        if (nextLevel == null) return;
        if (gameFinished == null) return;
    }

    public void GameOver() => gameOver.SetActive(true);

    public void GameFinished() => gameFinished.SetActive(true);

    public void QuitGame() => Application.Quit();

    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void Next_Level() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public void Next_Level(string levelName) => SceneManager.LoadScene(levelName);

    public void UpdateScoreText() => scoreText.text = totalScore.ToString();
}
