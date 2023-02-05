using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private string gitHubLink = "https://github.com/jiajin0329/2023GGJ_F";
    private void Start ()
    {
        BGMPlayer.self.Play ( "GameStart" );
    }

    public void StartGame()
    {
        SceneLoader.LoadScene(4);
        EffecyPlayer.self.Create ( "ClickButton" );   //������s����
    }

    public void ExitGame()
    {
        Application.Quit();
        EffecyPlayer.self.Create ( "ClickButton" );   //������s����
    }

    public void GoToURl()
    {
        Application.OpenURL(gitHubLink);
    }
}
