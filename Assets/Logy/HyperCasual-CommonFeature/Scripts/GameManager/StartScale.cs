using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScale : MonoBehaviour {
    [SerializeField] SettingObject[] objects;

    void Awake() {
        for(int i = 0; i < objects.Length; i++) {
            objects[i].gameObject.transform.localScale = Vector3.zero;
        }
    }
}
