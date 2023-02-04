using UnityEngine;
using DG.Tweening;

public class Fall_Into_The_Trash_Can : Interact_Event {
    [SerializeField] private ParticleEffect _particleEffect;
    public override void Play(Collision2D other) {
        Rigidbody2D toiletPaper = other.gameObject.GetComponent<Rigidbody2D>();
        toiletPaper.bodyType = RigidbodyType2D.Static;

        toiletPaper.transform.DOMove(transform.position, 0.5f);
        toiletPaper.transform.DOScale(Vector3.zero, 0.3f).OnComplete(()=> {
            _particleEffect.Play();
            transform.parent.DOShakeRotation(1f, 4f, 5);
            ResultJudge.Fail(1f);
        });
    }
}
