using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreboardManager : MonoBehaviour
{
    [SerializeField] private ScoreObject score;
    [SerializeField] private Text scoreText;
    private void Start()
    {
        scoreText.text = "SCORE: " + score.score;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    } 
}
