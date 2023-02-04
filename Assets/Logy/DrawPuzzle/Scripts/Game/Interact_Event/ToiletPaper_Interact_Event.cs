using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ToiletPaper_Interact_Event : MonoBehaviour {
    [SerializeField] private Interact_Event _interact_Event;

    private void OnTriggerEnter2D(Collider2D other) {
        if(ToiletPaper.layer != 0 && other.gameObject.layer != ToiletPaper.layer) return;
        
        _interact_Event.Play(other);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(ToiletPaper.layer != 0 && other.gameObject.layer != ToiletPaper.layer) return;

        _interact_Event.Play(other);
    }
}