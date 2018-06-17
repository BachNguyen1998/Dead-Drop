using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenuPanel;

    public void Resume() {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
