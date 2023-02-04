using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimEvent : MonoBehaviour {
    public UnityEvent animEvent;
    public void Event() {animEvent.Invoke();}

    public void Destory() {
        GameObject.Destroy(gameObject);
    }
}
