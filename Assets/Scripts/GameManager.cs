using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager self;
    private bool gameEnd = false;
    private void Awake()
    {
        self = this;
        if ( BGMPlayer.self == null )
        {
            SceneManager.LoadScene ( 0 );
            return;
        }
        BGMPlayer.self.Play ( "Game" );
    }

    [SerializeField] private Text scoreText;
    [SerializeField] private ScoreObject score;
    private float timePassed;
    private void Start()
    {
        timePassed = 0;
    }
    private void Update()
    {
        if (!gameEnd)
        {
            timePassed += Time.deltaTime;
            scoreText.text = "SCORE: " + timePassed.ToString("0.00");
        }
    }

    public void GameOver()
    {
        score.score = timePassed.ToString("0.00");
        gameEnd = true;
    }

    public void Scoreboard()
    {
        SceneManager.LoadScene(3);
    }
}
