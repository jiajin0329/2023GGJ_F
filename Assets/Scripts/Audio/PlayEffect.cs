using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffect : MonoBehaviour
{
    private bool isPlay = false;

    AudioSource audio;

    private void Start ()
    {
        audio = GetComponent<AudioSource> ();
    }

    private void Update ()
    {
        if ( isPlay == true && audio.isPlaying == false )
        {
            Destroy ( gameObject );
        }
    }

    public void Play ( AudioClip clip )
    {
        audio.clip = clip;
        audio.Play ();
        isPlay = true;
    }
}
