using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform Cam;
    public MeshRenderer BG;
    public MeshRenderer FG;

    [SerializeField]
    private float uv;

    [SerializeField] Animator playerAnimator;
    private float speed = 5f;
    private float jumpHeigth = 20f;
    private bool isGround = false;
    private float move;
    private bool dead = false;

    Rigidbody2D body;
    AudioSource audio;

    private void Start ()
    {
        body = GetComponent<Rigidbody2D> ();
        audio = GetComponent<AudioSource> ();
    }
    private void Update ()
    {
        Move ();
        Camera ();
        if (transform.position.y <= -5f && dead == false)
        {
            Die();
        }       
        CheckAnimationState();
        /*if ( audio.isPlaying == false && move != 0 && isGround == true )
        {
            audio.Play ();
        }

        if ( move == 0 || isGround == false )
            audio.Stop ();*/


        BG.material.SetTextureOffset("_MainTex", new Vector2( transform.localPosition.x * 0.002f  ,  0 ) );
        FG.material.SetTextureOffset("_MainTex", new Vector2( transform.localPosition.x * uv ,  0 ) );
    }

    private void CheckAnimationState()
    {
        if (!isGround)
        {
            playerAnimator.SetFloat("State", 2);
        }

        else if (move!=0)
        {
            playerAnimator.SetFloat("State", 1);
        }

        else
        {
            playerAnimator.SetFloat("State", 0);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            playerAnimator.SetBool("Shooting", true);
        }
        else
        {
            playerAnimator.SetBool("Shooting", false);
        }
    }

    void Move ()
    {
        if ( Input.GetKeyDown ( KeyCode.Space ) && isGround == true )
        {
            body.velocity = new Vector2 ( body.velocity.x , jumpHeigth );
            isGround = false;
            EffecyPlayer.self.Create ( "Jump" );
        }

        move = Input.GetAxis ( "Horizontal" );
        body.velocity = new Vector2 ( move * speed , body.velocity.y );
        Vector3 scale = transform.localScale;
        scale.x = move < 0? -1 : 1;
        transform.localScale = scale;
    }
    void Camera ()
    {
        Vector3 camPos = Cam.localPosition;
        camPos.x = Mathf.Max ( 0 , transform.localPosition.x );
        Cam.localPosition = camPos;
    }

   public void Die()
    {
        dead = true;
        GameManager.self.GameOver();
        EffecyPlayer.self.Create("Dead");
    }


    private void OnCollisionEnter2D ( Collision2D collision )
    {
        if ( collision.gameObject.tag == "Ground" )
        {
            isGround = true;
            EffecyPlayer.self.Create ( "Drop" );
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
