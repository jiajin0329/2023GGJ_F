using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {
    private Singleton() {}
    private static Singleton _singleton;

    private void Awake() {
        Singleton_Init();
    }

    public static void Example() {
        if(Cant_Execute()) return;
    }

    private void Singleton_Init() {
        _singleton = null;
        _singleton = this;
    }

    private static bool Cant_Execute() {
        return _singleton == null;
    }
}