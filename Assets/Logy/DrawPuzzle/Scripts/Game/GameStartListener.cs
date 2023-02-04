using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStartListener : MonoBehaviour {
    private GameStartListener() {}
    private static GameStartListener _singleton;

    [SerializeField] private UnityEvent _startEvent;

    private void Awake() {
        Singleton_Init();
    }

    public static void StartGame() {
        if(Cant_Execute()) return;
            _singleton._startEvent.Invoke();
            Destroy(_singleton.gameObject);
    }

    private void Singleton_Init() {
        _singleton = null;
        _singleton = this;
    }

    private static bool Cant_Execute() {
        return _singleton == null;
    }
}