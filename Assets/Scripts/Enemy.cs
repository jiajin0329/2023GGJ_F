using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    public VideoPlayer video;
    private float speed = 0.5f;

    private void FixedUpdate ()
    {
        if ( speed >= 4.5f )
            return;

        speed += 0.001f;
    }

    void Update()
    {
        transform.Translate ( new Vector3 ( speed * Time.deltaTime , 0 , 0 ) );

        float distance = Player.position.x - transform.position.x;
        if ( distance > 17f )
        {
            Vector3 pos = transform.position;
            pos.x = Player.position.x - 17f;
            transform.position = pos;
        }

        GetComponent<AudioSource> ().volume  = ( 10 - distance ) / 5f + 0.3f;
        if ( BGMPlayer.self == null )
        {
            SceneManager.LoadScene ( 0 );
            return;
        }
        BGMPlayer.self.GetComponent<AudioSource>().volume = ( distance - 5 ) / 20f ;
    }

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if ( collision.gameObject.tag == "Player" )
        {
            collision.GetComponent<Player>().Die();
            video.Play ();
        }

        if ( collision.gameObject.tag == "Ground" )
        {
            Destroy ( collision.gameObject , 2.0f );
        }
    }
}
