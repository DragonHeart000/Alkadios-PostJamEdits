using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UI;

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

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; // delete for release
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        UI.GetComponentInChildren<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
