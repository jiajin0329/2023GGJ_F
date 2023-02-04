using UnityEngine;
using DG.Tweening;

public class Shake : Interact_Event {
    public override void Play(Collision2D other) {
        transform.parent.DOShakeRotation(1f, 4f, 5);
    }
}
