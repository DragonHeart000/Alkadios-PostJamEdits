using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //public GameManager GM;
    Canvas pauseCanvas;

    public void TogglePauseMenu()
    {
        if (pauseCanvas.enabled)
        {
            pauseCanvas.enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            pauseCanvas.enabled = true;
            Time.timeScale = 0.0f;
        }
    }

    public void RestartLevel()
    {
        //Application.LoadLevel(Application.loadedLevel);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1.0f;
    }

    public void QuitToMainMenu()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas = GetComponentInChildren<Canvas>();
        pauseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        scanForPause();
    }

    void scanForPause()
    {
        if (Input.GetKeyDown("escape"))
            TogglePauseMenu();
    }
}
