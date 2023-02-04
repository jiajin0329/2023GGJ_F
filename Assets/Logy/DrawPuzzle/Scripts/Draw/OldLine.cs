using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLine : MonoBehaviour {
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _finishColor;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    
    private List<CapsuleCollider2D> _capsuleCollider2Ds = new List<CapsuleCollider2D>();

    private void Start() {
        CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D>();
        collider.radius = _lineRenderer.startWidth*0.5f;
        collider.isTrigger = true;
        LineColor(_startColor);
    }

    public void SetPosition(Vector2 pos) {
        if(!CanAppend(pos)) return;

        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount-1, pos);

        CreatCollider();
    }

    public void Finsih() {
        for(int i = 0; i < _capsuleCollider2Ds.Count; i++) {
            _capsuleCollider2Ds[i].enabled = true;
        }
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

        LineColor(_finishColor);
    }

    private bool CanAppend(Vector2 pos) {
        if(_lineRenderer.positionCount == 0) {
            return true;
        }

        return Vector2.Distance(_lineRenderer.GetPosition(_lineRenderer.positionCount-1), pos) > LineDrawer.resolution;
    }

    private void CreatCollider() {
        if(_lineRenderer.positionCount < 2) return;

        Vector2 currentPos = _lineRenderer.GetPosition(_lineRenderer.positionCount-1);
        Vector2 lastPost = _lineRenderer.GetPosition(_lineRenderer.positionCount-2);

        //new colliderObject
        GameObject colliderObject = new GameObject();
        colliderObject.name = "collider"; 
        colliderObject.transform.parent = transform;
        colliderObject.transform.localPosition = lastPost;

        //add capsuleCollider2D list
        _capsuleCollider2Ds.Add(colliderObject.AddComponent<CapsuleCollider2D>());
        int index = _capsuleCollider2Ds.Count-1;
        
        //disenable capsuleCollider2D
        _capsuleCollider2Ds[index].enabled = false;
        
        //set capsuleCollider2D angle;
        Vector2 differentPos = currentPos - lastPost;
        _capsuleCollider2Ds[index].transform.localEulerAngles = new Vector3(0f, 0f, -Logy.VectorAngle(differentPos));

        //set capsuleCollider2D length & offset
        float length = Vector2.Distance(Vector2.zero, differentPos);
        _capsuleCollider2Ds[index].size = new Vector2(_lineRenderer.startWidth, length + _lineRenderer.startWidth);
        _capsuleCollider2Ds[index].offset = new Vector2(0f, length*0.5f);
    }

    private void LineColor(Color color) {
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
    }
}
