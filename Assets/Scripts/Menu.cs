using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu self;
    private void Awake ()
    {
        self = this;
    }

    void Update()
    {
        if ( Input.GetKeyDown ( KeyCode.R ) )
            SceneManager.LoadScene ( 0 );
    }

    public void Dead ()
    {
        Debug.Log ( "GameOver" );
        EffecyPlayer.self.Create ( "Dead" );
    }
}
