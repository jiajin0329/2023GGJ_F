using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
    private static int _layer;
    public static int layer {get{return _layer;}}
    [SerializeField] private float strength;
    [SerializeField] private WaterParticle _waterParticlePrefab;
    [SerializeField] private float _duration = 0.02f;
    [SerializeField] private Transform _generatePoint;
    [SerializeField] private Camera _camera;

    private void Start() {
        _layer = _waterParticlePrefab.gameObject.layer;
        StartCoroutine(_ReleaseWater());
    }

    private Vector3 MousePosToWorldPos() {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector2 WaterVelocity() {
        return (MousePosToWorldPos() - _generatePoint.position) * strength;
    }

    private IEnumerator _ReleaseWater() {
        while(true) {
            yield return new WaitForSeconds(_duration);
            if(Input.GetKey(KeyCode.Mouse0)) {
                WaterParticle waterParticle = Instantiate(_waterParticlePrefab);
                waterParticle.transform.localScale = waterParticle.transform.localScale * (1f + Random.Range(-0.25f, 0.25f));
                waterParticle.rigidbody2D.position = _generatePoint.position;
                waterParticle.rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                waterParticle.rigidbody2D.velocity = WaterVelocity();
                waterParticle.LifeTIme();
            }
        }
    }
}