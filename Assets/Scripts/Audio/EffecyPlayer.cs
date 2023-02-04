using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffecyPlayer : MonoBehaviour
{
    public PlayEffect effect;

    public static EffecyPlayer self;
    private void Awake ()
    {
        self = this;
    }

    private const string audioPath = "Audio/";

    public void Create ( string path )
    {
        AudioClip clip = Resources.Load<AudioClip> ( audioPath + path );
        Play ( clip );
    }

    void Play ( AudioClip clip )
    {
        PlayEffect play = Instantiate ( effect , transform );
        play.Play ( clip );
    }
}
