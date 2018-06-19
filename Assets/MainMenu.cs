using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame() {
        LevelGenerator.y = -1.3f;
        LevelGenerator.level = 1;
        PlayScene();
        
        /*GameObject LG = GameObject.Find("LevelGenerator");
        LevelGenerator load=LG.GetComponent<LevelGenerator>();
        load.LoadLevel();*/
    }
    public static void PlayScene()
    {
        SceneManager.LoadSceneAsync("main");
    }
    public void QuitGame() {
        Application.Quit();
    }
}
