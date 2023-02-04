using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour {
    private LineDrawer() {}
    private static LineDrawer _singleton;

    [SerializeField] private bool _oneDraw;
    [SerializeField] private float _resolution = 0.1f;
    public static float resolution {get{return _singleton._resolution;}}
    [SerializeField] private Line _linePrefab;

    private bool _canDraw = true;
    public static bool canDraw {get{return _singleton._canDraw;}}
    private Camera _camera;
    private Line _currentLine;
    private Vector2 _startMouseWorldPos;
    private Vector2 _currentMouseWorldPos;
    private Vector2 _localMouseWorldPos;

    private void Awake() {
        Singleton_Init();
    }

    private void Start() {
        _camera = Camera.main;
    }

    private void Update() {
        if(_oneDraw && !_canDraw) return;

        if(Input.GetMouseButtonDown(0)) {
            if(_oneDraw && !_canDraw)
                return;
            else
                _canDraw = true;

            CreateDrawPoint();
        }

        if(!_canDraw) return;
        
        if(Input.GetMouseButton(0)) {
            Drawing();
        }

        if(Input.GetMouseButtonUp(0)) {
            EndDrawing();
            GameStartListener.StartGame();
        }
    }

    private void CreateDrawPoint() {
        _startMouseWorldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        _currentLine = Instantiate(_linePrefab, _startMouseWorldPos, Quaternion.identity);
    }

    private void Drawing() {
        _currentMouseWorldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        _localMouseWorldPos = _currentMouseWorldPos - _startMouseWorldPos;
        _currentLine.SetPosition(_localMouseWorldPos);
    }

    private void EndDrawing() {
        _canDraw = false;
        _currentLine.Finsih();
    }

    private void Singleton_Init() {
        _singleton = null;
        _singleton = this;
    }

    private static bool Cant_Execute() {
        return _singleton == null;
    }
}
