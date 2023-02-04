using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanRock : MonoBehaviour
{
    public Rock Rock;
    public Transform player;

    private int num = 0;
    private float distance = 4f;

    private void Start ()
    {
        for ( int i = 0; i < 5; i++ )
            Spwan ();
    }

    private void Update ()
    {
        if ( player.position.x > distance * ( num - 5 ) )
        {
            Spwan ();
        }
    }

    void Spwan ()
    {
        Rock rock = Instantiate<Rock> ( Rock , transform );
        rock.RanHeigth ( num * distance );
        num++;
    }
}
