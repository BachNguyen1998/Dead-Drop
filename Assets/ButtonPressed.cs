using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            LevelGenerator.level += 1;
            LevelGenerator.y += 1.3f;   
            Time.timeScale = 0.3f;
            Invoke("EnableWinning",2);
            Invoke("LoadNextLevel",4);           
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
    void LoadNextLevel()
    {
        WinningPanel.SetActive(false);
        /*GameObject LG = GameObject.Find("LevelGenerator");
        LevelGenerator load = LG.GetComponent<LevelGenerator>();
        load.LoadLevel();*/
        MainMenu.PlayScene();
    }
}   
