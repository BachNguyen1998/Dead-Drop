using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour {
    Animator anim;
    public GameObject WinningPanel;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("pressed",true);
            SoundManagerScript.PlaySound("buttonPressed");
            Time.timeScale = 0.3f;
            Invoke("EnableWinning",2);
        }    
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("pressed", false);
        }
    }
    void EnableWinning()
    {
        WinningPanel.SetActive(true);
    }
}
