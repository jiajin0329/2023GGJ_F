using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigibodyManager : MonoBehaviour {
    [SerializeField] protected Rigidbody2D _rigidbody2D;
    public new Rigidbody2D rigidbody2D {get{return _rigidbody2D;}}

    public void SetGravity(bool enable) {
        if(enable) {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }
        else {
             _rigidbody2D.bodyType = RigidbodyType2D.Static;
        }
    }
}
