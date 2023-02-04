using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public void RanHeigth ( float posX )
    {
        Vector3 pos = transform.localPosition;
        pos.x = posX;
        pos.y = Random.Range ( 0 , 3.5f );
        transform.localPosition = pos;
    }
}
