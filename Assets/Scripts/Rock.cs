using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Transform player;

    public void RanHeigth ( float posX )
    {
        Vector3 pos = transform.localPosition;
        pos.x = posX;
        pos.y = Random.Range ( 0 , 3.5f );
        transform.localPosition = pos;
    }
    private void Start ()
    {
        player = GameObject.Find ( "Player" ).transform;
    }
    private void Update ()
    {
        if ( player.localPosition.x - transform.localPosition.x > 5 )
            Destroy ( gameObject );
    }
}
