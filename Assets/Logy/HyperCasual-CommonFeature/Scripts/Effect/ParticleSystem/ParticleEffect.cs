using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour {
    [SerializeField] ParticleSystem _particleSystem;

    public void Play(Transform target) {
        transform.position = target.position;
        _particleSystem.Play();
    }
    public void Play() {
        _particleSystem.Play();
    }
}
