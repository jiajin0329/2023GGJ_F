using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Generator : MonoBehaviour {
    [SerializeField] Transform clone;
    [SerializeField] Transform parent;
    Transform instantiateObject;

    public void Generate() {
        instantiateObject = Instantiate(this.clone);

        if(parent != null) {
            instantiateObject.parent = parent;
            instantiateObject.localPosition = this.clone.localPosition;
            instantiateObject.gameObject.SetActive(true);
        }
    }

    public void PlayAnimation() {
        instantiateObject.GetComponent<Animation>().Play();
    }
}
