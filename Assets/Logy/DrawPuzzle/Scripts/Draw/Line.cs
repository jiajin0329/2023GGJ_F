using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _finishColor;
    [SerializeField] private PolygonCollider2D _polygonCollider2D;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    
    private float _colliderWidth;
    private List<Vector2> _points = new List<Vector2>(); 

    private void Start() {
        _colliderWidth = _lineRenderer.startWidth*0.5f;
        LineColor(_startColor);
    }

    public void SetPosition(Vector2 pos) {
        if(!CanAppend(pos)) return;
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount-1, pos);
    }

    public void Finsih() {
        SetCollider();
        _polygonCollider2D.enabled = true;
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        LineColor(_finishColor);
    }

    private bool CanAppend(Vector2 pos) {
        if(_lineRenderer.positionCount == 0) {
            return true;
        }

        return Vector2.Distance(_lineRenderer.GetPosition(_lineRenderer.positionCount-1), pos) > LineDrawer.resolution;
    }

    private void LineColor(Color color) {
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
    }

    private void SetCollider() {
        Vector2 currentPos;
        Vector2 nextPos;
        Vector2 differentPos;
        float radian;
        float angle;
        int i;
        for(i = 0; i < _lineRenderer.positionCount; i++) {
            currentPos = _lineRenderer.GetPosition(i);
            nextPos = _lineRenderer.GetPosition(i+1);
            differentPos = nextPos - currentPos;
            angle = Logy.VectorAngle(differentPos);

            if(i < 1) {
                _points.Add(Logy.Angle2VectorPosition(angle-90f, _colliderWidth) + currentPos);
            }
            else {
                _points.Add(Logy.Angle2VectorPosition(angle-90f, _colliderWidth) + currentPos);
            }

            if(i > _lineRenderer.positionCount-3) {
                _points.Add(Logy.Angle2VectorPosition(angle-90f, _colliderWidth) + nextPos);
                break;
            }
        }
        
        for(i = _lineRenderer.positionCount-1; i > -1; i--) {
            currentPos = _lineRenderer.GetPosition(i);
            nextPos = _lineRenderer.GetPosition(i-1);
            differentPos = nextPos - currentPos;
            radian = Logy.VectorRadian(differentPos);
            angle = Logy.VectorAngle(differentPos);

            if(i > _lineRenderer.positionCount-2) {
                _points.Add(Logy.Angle2VectorPosition(angle-90f, _colliderWidth) + currentPos);
            }
            else {
                _points.Add(Logy.Angle2VectorPosition(angle-90f, _colliderWidth) + currentPos);
            }

            if(i < 2) {
                _points.Add(Logy.Angle2VectorPosition(angle-90f, _colliderWidth) + nextPos);
                break;
            }
        }
        
        _polygonCollider2D.points = _points.ToArray();
    }
}
