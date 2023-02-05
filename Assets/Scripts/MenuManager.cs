using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start ()
    {
        BGMPlayer.self.Play ( "GameStart" );
    }

    public void StartGame()
    {
        SceneLoader.LoadScene(4);
        EffecyPlayer.self.Create ( "ClickButton" );   //播放按鈕音效
    }

    public void ExitGame()
    {
        Application.Quit();
        EffecyPlayer.self.Create ( "ClickButton" );   //播放按鈕音效
    }
}
