using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(2);
        EffecyPlayer.self.Create ( "ClickButton" );   //������s����
    }

    public void ExitGame()
    {
        Application.Quit();
        EffecyPlayer.self.Create ( "ClickButton" );   //������s����
    }
}
