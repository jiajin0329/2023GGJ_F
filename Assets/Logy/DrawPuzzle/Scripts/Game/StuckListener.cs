using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckListener : MonoBehaviour {
    private StuckListener() {}
    private static StuckListener _singleton;

    [SerializeField] private float _listenDuration;
    [SerializeField] private float _retimeDistance = 0.2f;
    [SerializeField] private float _waitTime = 1f;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Vector2 _currentPos, _lastPos;
    private float _currentToiletPaperMoveDistance;
    private float _stuckTime = 0f;
    private Coroutine _coroutine;

    private void Awake() {
        Singleton_Init();
    }

    private void Start() {
        _coroutine = StartCoroutine(Listener());
    }

    private void Singleton_Init() {
        _singleton = null;
        _singleton = this;
    }

    private bool Cant_Execute() {
        return _singleton == null;
    }

    private IEnumerator Listener() {
        _lastPos = _currentPos = _rigidbody2D.position;
        while(_stuckTime < _waitTime) {
            yield return new WaitForSeconds(_listenDuration);
            if(_rigidbody2D == null) break;

            if(!LineDrawer.canDraw) {
                _stuckTime += _listenDuration;
                _currentPos = _rigidbody2D.position;
                _currentToiletPaperMoveDistance = Vector2.Distance(_lastPos, _currentPos);
                if(_currentToiletPaperMoveDistance >= _retimeDistance) {
                    _stuckTime = 0f;
                    _lastPos = _rigidbody2D.position;
                }
            }
        }

        if(_stuckTime >= _waitTime) {
            ResultJudge.Fail(1f);
        }
    }

    public static void StopListen() {
        if(_singleton._coroutine != null)
            _singleton.StopCoroutine(_singleton._coroutine);
    }
}