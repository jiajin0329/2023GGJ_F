using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrowUp : DoTweenEffect {
    [SerializeField] Vector3 _scale;
    private void Awake() {
        transform.localScale = new Vector3(1f, 0f, 1f);
    }

    protected override void Play() {
        float wait = _duration *0.5f;
        transform.DOScale(new Vector3(_scale.x*0.8f, _scale.y*1.2f, _scale.z*0.8f), wait).OnComplete(()=> {
            transform.DOScale(_scale, wait);
        });
    }
}