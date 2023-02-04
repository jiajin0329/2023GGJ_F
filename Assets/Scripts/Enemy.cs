using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;

    [SerializeField]
    private float speed = 2f;

    private void FixedUpdate ()
    {
        if ( speed >= 4.5f )
            return;

        speed += 0.001f;
    }

    void Update()
    {
        transform.Translate ( new Vector3 ( speed * Time.deltaTime , 0 , 0 ) );

        if ( Player.position.x - transform.position.x > 17f )
        {
            Vector3 pos = transform.position;
            pos.x = Player.position.x - 17f;
            transform.position = pos;
        }
    }

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if ( collision.gameObject.tag == "Player" )
        {
            GameManager.self.GameOver();
            collision.GetComponent<Player> ().enabled = false;
        }

        if ( collision.gameObject.tag == "Ground" )
        {
            Destroy ( collision.gameObject , 2.0f );
        }
    }
}
