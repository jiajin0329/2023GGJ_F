using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeInOut : Transition {
    [SerializeField] float costTime;
    [SerializeField] Image image;

    private void Start() {
        PlayEvent.AddListener(TransitionIn);
        FinishEvent.AddListener(TransitionOut);
    }

    public override float CostTime() {
        return costTime;
    }

    protected override void TransitionIn () {
        image.gameObject.SetActive(true);
        image.DOFade(1f, costTime);
    }

    protected override void TransitionOut() {
        image.DOFade(0f, costTime).OnComplete(() => {
            End(0f);
        });
    }
}
