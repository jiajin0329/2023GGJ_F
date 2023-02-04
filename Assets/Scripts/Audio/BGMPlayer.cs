using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public static BGMPlayer self;
    private void Awake ()
    {
        self = this;
    }

    [HideInInspector]
    public AudioSource audio;
    private const string audioPath = "Audio/BGM/";

    private void Start ()
    {
        audio = GetComponent<AudioSource> ();
    }

    public void Play ( string clipPath )
    {
        AudioClip clip = Resources.Load<AudioClip> ( audioPath + clipPath );
        audio.clip = clip;
        audio.Play ();
    }
}
