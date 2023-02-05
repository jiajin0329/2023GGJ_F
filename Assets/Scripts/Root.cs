using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Root : MonoBehaviour
{
    public BoxCollider2D PlantColloder;
    public BoxCollider2D RootColloder;
    public ParticleSystem particle;

    private int waterNum;
    private int level = 0;
    private int [] grow = new [] { 2 , 4 , 6 , 8 , 10 };
    private float speed = 1f;

    BoxCollider2D player;
    Animator anim;

    private void Start ()
    {
        anim = GetComponent<Animator> ();
        player = GameObject.Find ( "Player" ).GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision ( GetComponent<BoxCollider2D> () , player , true );
    }

    private void OnCollisionEnter2D ( Collision2D collision )
    {
        if ( collision.gameObject.tag == "Water" )
        {
            waterNum++;
            collision.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
            collision.gameObject.GetComponent<WaterParticle> ().WaterDisappear ();
            if ( level >= 5 )
                return;

            if ( waterNum >= grow[level] )
                anim.speed = 1;
        }
    }

    void Grow1 ()
    {
        EffecyPlayer.self.Create ( "Grow" );
        level = 1;
        if ( waterNum >= grow[0] )
            return;
        anim.speed = 0;
    }

    void Grow2 ()
    {
        EffecyPlayer.self.Create ( "Grow" );
        level = 2;
        if ( waterNum >= grow[1] )
            return;
        anim.speed = 0;
    }

    void Grow3 ()
    {
        EffecyPlayer.self.Create ( "Grow" );
        level = 3;
        if ( waterNum >= grow[2] )
            return;
        anim.speed = 0;
    }

    void Grow4 ()
    {
        EffecyPlayer.self.Create ( "Grow" );
        level = 4;
        if ( waterNum >= grow[3] )
            return;
        anim.speed = 0;
    }

    void Grow5 ()
    {
        EffecyPlayer.self.Create ( "Grow" );
        level = 5;
        if ( waterNum >= grow[4] )
            return;
        anim.speed = 0;
    }

    void Grow6 ()
    {
        EffecyPlayer.self.Create ( "Finish" );
        particle.Play ();
        PlantColloder.enabled = false;
        RootColloder.enabled = true;
    }

}
