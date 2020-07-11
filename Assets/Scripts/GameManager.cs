using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager UI;
    public DialogueManager DM;

    public void TogglePauseMenu()
    {
        if (UI.GetComponentInChildren<Canvas>().enabled)
        {
            UI.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            UI.GetComponentInChildren<Canvas>().enabled = true;
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
        UnityEditor.EditorApplication.isPlaying = false; // delete for release?
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        DM.GetComponentInChildren<Canvas>().enabled = false;
        UI.GetComponentInChildren<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
