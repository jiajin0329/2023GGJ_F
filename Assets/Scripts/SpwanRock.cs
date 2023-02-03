using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanRock : MonoBehaviour
{
    public Rock Rock;

    private int num = 0;
    private float distance = 4f;

    private void Start ()
    {
        for ( int i = 0; i < 5; i++ )
            Spwan ();
    }
    public void Spwan ()
    {
        Rock rock = Instantiate<Rock> ( Rock , transform );
        rock.RanHeigth ( num * distance );
        num++;
        Invoke ( "Spwan" , 2f );
    }
}
