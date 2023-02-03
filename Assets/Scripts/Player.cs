using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform Cam;

    private float speed = 7f;
    private float gravity = -9.81f;
    private float jumpHeight = 15f;
    private bool isGround;
    private Vector3 playerVelocity;

    CharacterController player;

    private void Start ()
    {
        player = GetComponent<CharacterController> ();
    }
    private void Update ()
    {
        Move ();
        Camera ();
    }

    void Move ()
    {
        isGround = player.isGrounded;

        Vector3 move = new Vector3 ( Input.GetAxis ( "Horizontal" ) , 0 , 0 );
        player.Move ( move * Time.deltaTime * speed );

        if ( move != Vector3.zero )
        {
            gameObject.transform.forward = move;
        }

        if ( Input.GetKey ( KeyCode.W ) && isGround )
        {
            playerVelocity.y += jumpHeight;
        }

        playerVelocity.y += gravity * Time.deltaTime;
        player.Move ( playerVelocity * Time.deltaTime );
    }
    void Camera ()
    {
        Vector3 camPos = Cam.localPosition;
        camPos.x = Mathf.Max ( 0 , player.transform.localPosition.x );
        Cam.localPosition = camPos;
    }
}
