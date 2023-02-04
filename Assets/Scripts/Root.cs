using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Root : MonoBehaviour
{
    BoxCollider2D player;

    private float speed = 1f;



    private void Start ()
    {
        player = GameObject.Find ( "Player" ).GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision ( GetComponent<BoxCollider2D> () , player , true );
    }


    private void OnCollisionEnter2D ( Collision2D collision )
    {
        if ( collision.gameObject.tag == "Water" )
        {
            collision.gameObject.GetComponent<WaterParticle> ().WaterDisappear ();
        }
    }
    private void OnMouseDrag ()
    {
        if ( transform.localScale.x >= 1 )
            return;

        transform.localScale += new Vector3 ( speed * Time.deltaTime , 0 , 0 );
        if ( transform.localScale.x >= 1 )
        {
            Physics2D.IgnoreCollision ( GetComponent<BoxCollider2D> () , player , false );
            GetComponent<SpriteRenderer> ().color = Color.green;
        }
    }

}
