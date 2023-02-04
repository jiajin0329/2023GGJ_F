using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dontdestory : MonoBehaviour
{
    void Awake ()
    {
        DontDestroyOnLoad ( gameObject );
        SceneManager.LoadScene ( 1 );
    }
}
