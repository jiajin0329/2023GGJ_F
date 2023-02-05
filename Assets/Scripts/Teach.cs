using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Teach : MonoBehaviour
{
    public VideoPlayer video;

    private void Start ()
    {
        BGMPlayer.self.Play ( "Menu" );
        StartCoroutine ( "Play" );
    }

    IEnumerator Play ()
    {
        Debug.Log (video.isPrepared);
        while ( video.isPrepared == false )
        {
            yield return null;
        }
        video.Play ();
        Debug.Log (video.isPlaying );
        while ( video.isPlaying )
        {
            yield return null;
        }
        Debug.Log (video.isPlaying );

        SceneManager.LoadScene ( 2 );
    }

    public void Skip ()
    {
        SceneLoader.LoadScene ( 2 );
    }
}
