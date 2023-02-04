using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTweenEffect : MonoBehaviour {
    [SerializeField] private bool _startOnAwake;
    [SerializeField] protected float _duration;

    protected void Start() {
        if(_startOnAwake)
            Play();
    }

    protected virtual void Play() {}
}
