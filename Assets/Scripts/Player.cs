using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform Cam;
    
    private float speed = 5f;
    private float jumpHeigth = 20f;
    private bool isGround = false;

    Rigidbody2D body;

    private void Start ()
    {
        body = GetComponent<Rigidbody2D> ();
    }
    private void Update ()
    {
        Move ();
        Camera ();
        Die ();
    }

    void Move ()
    {
        if ( Input.GetKeyDown ( KeyCode.Space ) && isGround == true )
        {
            body.velocity = new Vector2 ( body.velocity.x , jumpHeigth );
            isGround = false;
            EffecyPlayer.self.Create ( "Jump" );
        }

        float move = Input.GetAxis ( "Horizontal" );
        body.velocity = new Vector2 ( move * speed , body.velocity.y );


    }
    void Camera ()
    {
        Vector3 camPos = Cam.localPosition;
        camPos.x = Mathf.Max ( 0 , transform.localPosition.x );
        Cam.localPosition = camPos;
    }

    void Die ()
    {
        if ( transform.position.y <= -5f )
        {
            Menu.self.Dead ();
            this.enabled = false;
        }
    }


    private void OnCollisionEnter2D ( Collision2D collision )
    {
        if ( collision.gameObject.tag == "Ground" )
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D ( Collision2D collision )
    {
        if ( collision.gameObject.tag == "Ground" )
        {
            isGround = false;
        }
    }
}
