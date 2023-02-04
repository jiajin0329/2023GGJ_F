using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSetting : MonoBehaviour {
    [SerializeField] bool startOnHide;
    [SerializeField] Vector3[] position;
    [SerializeField] Vector3[] angle;
    [SerializeField] Vector3[] scale;

    void Awake() {
        if(position.Length > 0)
            transform.localPosition = position[0];
        if(angle.Length > 0)
            transform.localEulerAngles = angle[0];
        if(scale.Length > 0)
            transform.localScale = scale[0];

        if(startOnHide)
            gameObject.SetActive(false);
    }
}
