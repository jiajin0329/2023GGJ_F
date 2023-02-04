using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager self;
    private void Awake()
    {
        self = this;
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
        timePassed += Time.deltaTime;
        scoreText.text = "SCORE: " + timePassed.ToString("0.00");

        if (Input.GetKeyDown(KeyCode.I))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        score.score = timePassed.ToString("0.00");
        SceneManager.LoadScene(3);
    }
}
