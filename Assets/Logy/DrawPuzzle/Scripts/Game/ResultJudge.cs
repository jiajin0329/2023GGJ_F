using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ResultJudge : MonoBehaviour {
    private ResultJudge() {}
    private static ResultJudge _singleton;
    
    private static int _layer;
    public static int layer {get{return _layer;}}
    [SerializeField] private float _delayShowUI = 1f;
    [SerializeField] private Transform _goalMove;
    [SerializeField] private LayerMask _triggerMask;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject[] _hideObjects;
    [SerializeField] private Sprite _success;
    [SerializeField] private Sprite _fail;
    [SerializeField] private Sprite _wet;
    [SerializeField] private Sprite _wetToiletPaper;

    private byte _wetCount;
    private bool _finsih;

    private void Awake() {
        Singleton_Init();
    }

    private void Start() {
        _layer = gameObject.layer;
    }

    public static void Success(float delay) {
        if(Cant_Execute()) return;
        _singleton._finsih = true;
        _singleton.HideObjects();
        _singleton._spriteRenderer.sprite = _singleton._success;
        ResultUI.ShowSuccessUI(delay);
    }

    public static void Fail(float delayResultUI) {
        if(Cant_Execute()) return;
        _singleton.StartCoroutine(_Fail(delayResultUI));
    }
    private static IEnumerator _Fail(float delayResultUI) {
        _singleton._finsih = true;
        _singleton.HideObjects();
        _singleton._spriteRenderer.sprite = _singleton._fail;
        ResultUI.ShowFailedUI(delayResultUI);
        yield return null;
    }

    public static void Wet(float delayResultUI) {
        if(Cant_Execute()) return;

        if(_singleton._wetCount < 5) {
            _singleton._wetCount++;
            return;
        }
        
        _singleton._finsih = true;
        _singleton.HideObjects();
        _singleton._spriteRenderer.sprite = _singleton._wet;
        ResultUI.ShowFailedUI(delayResultUI);
    }

    public static void Wet_ToiletPaper(float delayResultUI) {
        if(Cant_Execute()) return;

        _singleton._finsih = true;
        _singleton.HideObjects();
        _singleton._spriteRenderer.sprite = _singleton._wetToiletPaper;
        ResultUI.ShowFailedUI(delayResultUI);
    }

    private static bool Cant_Execute() {
        return _singleton == null
        || _singleton._finsih;
    }

    private void HideObjects() {
        for(int i = 0; i < _singleton._hideObjects.Length; i++) {
            _singleton._hideObjects[i].SetActive(false);
        }
    }

    private void Singleton_Init() {
        _singleton = null;
        _singleton = this;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(ToiletPaper.layer != 0) {
            if(other.gameObject.layer == ToiletPaper.layer) {
                ToiletPaper toiletPaper = other.gameObject.GetComponent<ToiletPaper>();
                toiletPaper.rigibodyManager.SetGravity(false);
                StuckListener.StopListen();
                toiletPaper.transform.DOMove(_goalMove.position, 1f).OnComplete(()=> {
                    if(toiletPaper.wet) {
                        other.gameObject.SetActive(false);
                        Wet_ToiletPaper(2f);
                        ResultUI.ShowFailedUI(_delayShowUI);
                    }                
                    else {
                        other.gameObject.SetActive(false);
                        Success(2f);
                        ResultUI.ShowSuccessUI(_delayShowUI);
                    }
                });
            }
        }
        
        if(Water.layer != 0) {
            if(other.gameObject.layer == Water.layer) {
                ResultJudge.Wet(2f);
            }
        }
    }
}
