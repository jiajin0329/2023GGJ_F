using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logy {
    public static IEnumerator DoThrow(Transform transform, Transform target, float duration) {
        Vector3 start = transform.position;
        transform.parent = null;
        Vector3 center;

        float time = 0f;
        float timeSpeed = 1f/duration;

        while(true) {
            yield return new WaitForEndOfFrame();
            time += timeSpeed*Time.deltaTime;
            if(time > 1f) break;

            center = (start+target.position)*0.5f;
            center.y = target.position.y + 3f;

            transform.position = (1 - time) * (1 - time) * start + 2 * time * (1 - time) * center + time * time * target.position;
        }
    }

    public static Vector3 GetBezierPoint(float time, Vector3 start, Vector3 center, Vector3 end) {
        return (1 - time) * (1 - time) * start + 2 * time * (1 - time) * center + time * time * end;
    }

    public static IEnumerator DoMove(Transform transform, Transform target, float duration) {
        Vector3 start = transform.position;
        transform.parent = null;

        float time = 0f;
        float timeSpeed = 1f/duration;
        while(true) {
            yield return new WaitForEndOfFrame();
            time += timeSpeed*Time.deltaTime;
            if(time > 1f) break;

            transform.position = start + time * (target.position-start);
        }
    }
    public static IEnumerator DoMove(Transform transform, Transform target, Vector3 offset, float duration) {
        Vector3 start = transform.position;
        transform.parent = null;

        float time = 0f;
        float timeSpeed = 1f/duration;
        while(true) {
            yield return new WaitForEndOfFrame();
            time += timeSpeed*Time.deltaTime;
            if(time > 1f) break;

            transform.position = start + time * (target.position + offset - start);
        }
    }

    public static int LayerMaskToInt(LayerMask layerMask) {
        return (int)Mathf.Log(layerMask.value, 2f);
    }

    public static float VectorRadian(float x, float y) {
        return Mathf.Atan2(x, y);
    }
    public static float VectorRadian(Vector2 input) {
        return Mathf.Atan2(input.x, input.y);
    }
    public static float VectorAngle(float x, float y) {
        return Mathf.Atan2(x, y) * Mathf.Rad2Deg;
    }
    public static float VectorAngle(Vector2 input) {
        return Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
    }

    public static Vector2 Radian2VectorPosition(float radian, float radius) {
        Vector2 position;
        position.x = radius * Mathf.Sin(radian);
        position.y = radius * Mathf.Cos(radian);
        return position;
    }
    public static Vector2 Angle2VectorPosition(float angle, float radius) {
        Vector2 position;
        position.x = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        position.y = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        return position;
    }
}