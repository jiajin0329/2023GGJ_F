using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    BGMPlayer self;
    private void Awake ()
    {
        self = this;
    }


    AudioSource audio;

    private void Start ()
    {
        audio = GetComponent<AudioSource> ();
    }

    public void Play ( AudioClip clip )
    {
        audio.clip = clip;
        audio.Play ();
    }
}
