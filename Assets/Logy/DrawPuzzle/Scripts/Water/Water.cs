using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
    private static int _layer;
    public static int layer {get{return _layer;}}
    [SerializeField] private WaterParticle _waterParticlePrefab;
    [SerializeField] private float _duration = 0.02f;
    [SerializeField] private Transform _generatePoint;

    private void Start() {
        _layer = _waterParticlePrefab.gameObject.layer;
        StartCoroutine(_ReleaseWater());
    }

    private IEnumerator _ReleaseWater() {
        while(true) {
            yield return new WaitForSeconds(_duration);
            WaterParticle waterParticle = Instantiate(_waterParticlePrefab, transform);
            waterParticle.transform.localScale = waterParticle.transform.localScale * (1f + Random.Range(-0.25f, 0.25f));
            waterParticle.rigidbody2D.position = _generatePoint.position;
            waterParticle.rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            waterParticle.LifeTIme();
        }
    }
}