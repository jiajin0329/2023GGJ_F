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

    private void OnCollisionEnter ( Collision collision )
    {
        Debug.Log ( collision.gameObject.name + collision.gameObject.tag);
        if ( collision.gameObject.tag == "Player" )
        {
            Debug.Log ("GameOver");
        }
    }
}
