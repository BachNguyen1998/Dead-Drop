using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour {
    public static int level=0;
    public TextMeshProUGUI levelText;
    public GameObject levelPanel;
    public GameObject platform;
    Vector3 spawnPosition = new Vector3();
    public float height = 1.3f;
    public float x = 1.97f;
    public static float y=-1.3f;
    bool created = false;

    void Start()
    {
        /*levelPanel.SetActive(true);
        //Time.timeScale = 0.2f;
        Invoke("disablePanel", 1);
        
        Invoke("LoadLevelDelay", 1);
        */
        spawnPlatform();
        Time.timeScale = 0.5f;
        levelText.text = "LEVEL " + level;
        Invoke("disablePanel", 2);
    }
    void disablePanel()
    {
        Time.timeScale = 1f;
        levelPanel.SetActive(false);
    }
    void spawnPlatform()
    {
        spawnPosition.x = x;
        spawnPosition.y = y;
        Instantiate(platform,spawnPosition,Quaternion.identity);
    }
}
