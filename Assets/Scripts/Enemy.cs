using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2f;
    void Update()
    {
        transform.Translate ( new Vector3 ( speed * Time.deltaTime , 0 , 0 ) );
    }

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if ( collision.gameObject.tag == "Player" )
        {
            Debug.Log ("GameOver");
        }
    }
}
