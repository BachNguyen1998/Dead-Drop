using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchDown : MonoBehaviour {
    void Start()
    {  
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManagerScript.PlaySound("land");
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        SoundManagerScript.PlaySound("jump");    
    }
}
