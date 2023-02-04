using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterParticle : MonoBehaviour {
    [SerializeField] private float _lifeTime;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public new Rigidbody2D rigidbody2D {get{return _rigidbody2D;}}
    [SerializeField] private LayerMask _toiletPaperMask;
    [SerializeField] private LayerMask _characterLayerMask;
    private bool _enable = true;

    public void LifeTIme() {
        StartCoroutine(_LifeTIme());
    }
    public IEnumerator _LifeTIme () {
        yield return new WaitForSeconds(_lifeTime*0.8f);
        WaterDisappear();
    }

    public void WaterDisappear() {
        _enable = false;
        transform.DOScale(Vector3.zero, _lifeTime*0.2f).OnComplete(()=> {
            Destroy(gameObject);
        });
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(ToiletPaper.layer != 0) {
            if(other.gameObject.layer == ToiletPaper.layer) {
                WaterDisappear();
            }
        }
        
        if(ResultJudge.layer != 0) {
            if(other.gameObject.layer == ToiletPaper.layer && _enable) {
                ResultJudge.Wet(2f);
            }
        }
    }
}
