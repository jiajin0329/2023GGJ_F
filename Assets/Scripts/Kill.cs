using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Kill : MonoBehaviour
{
    public VideoPlayer video;
    public ParticleSystem particle;

    private void Start ()
    {
        //BGMPlayer.self.audio.Stop ();
        StartCoroutine ( "Play" );
    }

    IEnumerator Play ()
    {
        while ( video.isPrepared == false )
        {
            yield return null;
        }
        video.Play ();
        while ( video.isPlaying )
        {
            yield return null;
        }
        ParticleSystem par = Instantiate ( particle );
        DontDestroyOnLoad ( par.gameObject );
        par.Play ();
        //Destroy ( par.gameObject , 5f );

        SceneLoader.LoadScene ( 3 );
    }
}
