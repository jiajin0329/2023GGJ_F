using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanRock : MonoBehaviour
{
    public Rock [] Rocks;
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
        Rock rock = Instantiate<Rock> ( Rocks [0] , transform );
        rock.RanHeigth ( num * distance );
        num++;
    }

    void Spwan ()
    {
        int ran = Random.Range ( 0 , 2 );
        Rock rock = Instantiate<Rock> ( Rocks [ran] , transform );
        rock.RanHeigth ( num * distance );
        num++;
    }
}
