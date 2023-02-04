using UnityEngine;

public class Fail : Interact_Event {
    [SerializeField] private float dealy = 1f;
    public override void Play(Collider2D other) {
        Destroy(other.gameObject);
        ResultJudge.Fail(dealy);
    }
}
