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
        Debug.Log (audioPath + path);
        AudioClip clip = Resources.Load<AudioClip> ( audioPath + path );
        Debug.Log ( clip.name );
        Play ( clip );
    }

    void Play ( AudioClip clip )
    {
        PlayEffect play = Instantiate ( effect , transform );
        play.Play ( clip );
    }
}
