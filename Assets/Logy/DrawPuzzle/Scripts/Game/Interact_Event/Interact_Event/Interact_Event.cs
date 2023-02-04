using UnityEngine;

public class Interact_Event : MonoBehaviour {
    public virtual void Play(Collider2D other) {}
    public virtual void Play(Collision2D other) {}
}
