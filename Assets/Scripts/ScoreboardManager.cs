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
        scoreText.text = "YOUR SCORE: " + score.score;
        if ( BGMPlayer.self != null )
            BGMPlayer.self.Play( "Score" );
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    } 
}
