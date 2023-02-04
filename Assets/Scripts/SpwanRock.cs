using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanRock : MonoBehaviour
{
    public Ground [] Grounds;
    public Transform player;

    private int num = 2;
    private float distance = 4f;

    private void Start ()
    {
        for ( int i = 0; i < 3; i++ )
            SpwanDefault ();
    }

    private void Update ()
    {
        if ( player.position.x > distance * ( num - 5 ) )
        {
            Spwan ();
        }
    }

    void SpwanDefault ()
    {
        Ground ground = Instantiate ( Grounds [0] , transform );
        ground.RanHeigth ( num * distance );
        num++;
    }

    void Spwan ()
    {
        int ran = Random.Range ( 0 , 2 );
        Ground ground = Instantiate ( Grounds [ran] , transform );
        ground.RanHeigth ( num * distance );
        num++;
    }
}
