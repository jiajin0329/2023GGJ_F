using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ToiletPaper : MonoBehaviour {
    private static int _layer;
    public static int layer {get{return _layer;}}
    [SerializeField] private RigibodyManager _rigibodyManager;
    public RigibodyManager rigibodyManager {get{return _rigibodyManager;}}
    [SerializeField] private bool _wet = false;
    public bool wet {get{return _wet;}}
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _wetSprite;

    private void Start() {
        _layer = gameObject.layer;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(Water.layer != 0) {
            if(other.gameObject.layer == Water.layer) {
                _wet = true;
                _spriteRenderer.sprite = _wetSprite;
            }
        }
    }
}