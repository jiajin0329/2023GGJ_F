using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Root : MonoBehaviour
{
    private float speed = 1f;

    private void OnMouseDrag ()
    {
        if ( transform.localScale.x >= 1 )
            return;

        transform.localScale += new Vector3 ( speed * Time.deltaTime , 0 , 0 );
        if ( transform.localScale.x >= 1 )
        {
            GetComponent<BoxCollider2D> ().isTrigger = false;
            GetComponent<SpriteRenderer> ().color = Color.green;
        }
    }
}
