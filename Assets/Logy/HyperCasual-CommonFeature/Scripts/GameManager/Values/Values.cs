using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Values : MonoBehaviour {
    public uint current;
    public uint max;
    [System.NonSerialized] public UnityEvent StartEvent = new UnityEvent();
    public UnityEvent ChangeEvent;

    void Start(){
        StartEvent.Invoke();
    }

    public bool Add(float add) {
        bool valueChanged = false;
        if(add > 0) {
            current += (uint)add;
            valueChanged = true;
        }
        else {
            if(-add <= current) {
                current += (uint)add;
                valueChanged = true;
            }
        }
        Limit();
        if(valueChanged)
            ChangeEvent.Invoke();
        return valueChanged;
    }
    public bool Set(float set) {
        bool valueChanged = false;
        if(set > 0) {
            current = (uint)set;
            valueChanged = true;
        }
        Limit();
        if(valueChanged)
            ChangeEvent.Invoke();
        return valueChanged;
    }

    void Limit() {
        if(current > max) {
            current = max;
        }
    }
}
