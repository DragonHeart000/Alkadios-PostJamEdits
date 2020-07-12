using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Runtime.Versioning;

public class DialogueManager : MonoBehaviour
{
    const string INTRO_PATH = "Assets/Resources/intro.txt";
    const string MOUNT_PATH = "Assets/Resources/mountains_end.txt";
    const string CATA_START_PATH = "Assets/Resources/catacomb_start.txt";
    const string CATA_END_PATH = "Assets/Resources/catacomb_end.txt";
    const string BEACH_START_PATH = "Assets/Resources/beach_start.txt";
    const string TEST_PATH = "Assets/Resources/testscript.txt";
    const string TEST_PATH_ALT = "Assets/Resources/testscriptalt.txt";

    //StreamReader sr;
    public TextMeshProUGUI DialogueText;
    public Image speakerImage;
    public Button NextLineButton;
    Canvas dialogueCanvas;
    int currentLine = 0;
    //public TextAsset json;
    DialogueLine[] lines;
    int nextLevel = -1;

    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }

    [Serializable]
    public class DialogueLine
    {
        public string speaker;
        public string text;
    }

    [Serializable]
    public class RootObject
    {
        public DialogueLine[] lines;
    }

    public string getFileForScene(string scene, bool isEnd)
    {
        string path = "";
        switch (scene)
        {
            case "Level 1":
                if (isEnd)
                    path = MOUNT_PATH;
                else
                    path = INTRO_PATH;
                break;
            case "Level 2":
                if (isEnd)
                    path = CATA_END_PATH;
                else
                    path = CATA_START_PATH;
                break;
            case "Level 3":
                if (isEnd)
                    path = "";
                else
                    path = BEACH_START_PATH;
                break;
            case "DialogueTest":
                if (isEnd)
                    path = TEST_PATH_ALT;
                else
                    path = TEST_PATH;
                break;
        }
        return path;
    }

    public DialogueLine[] loadLines(string path)
    {
        Debug.Log(path);
        string jsonString = File.ReadAllText(path);
        //List<DialogueLine> scriptLines = new List<DialogueLine>();
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);
        //scriptLines = JsonUtility.FromJson<DialogueLine>(jsonString)
        DialogueLine[] scriptLines = root.lines;
        return scriptLines;
    }

    public void startDialogue(int scene)
    {
        nextLevel = scene;
        bool isEnd = (nextLevel != -1);
        string path = getFileForScene(SceneManager.GetActiveScene().name, isEnd);

        if (!File.Exists(path))
        {
            Debug.Log("File doesn't exist, cannot read");
            return;
        }

        lines = loadLines(path);

        if (dialogueCanvas.enabled)
        {
            dialogueCanvas.enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            dialogueCanvas.enabled = true;
            Time.timeScale = 0.0f;
        }

        //sr = new StreamReader(path);
        nextLine();
    }

    public void nextLine()
    {
        if (currentLine < lines.Length && lines[currentLine] != null)
        {
            DialogueText.text = lines[currentLine].text;
            // placeholder names throughout
            switch (lines[currentLine].speaker)
            {
                case "Alkadios":
                    speakerImage = Resources.Load<Image>("AlkadiosImage");
                    break;
                case "Athena":
                    speakerImage = Resources.Load<Image>("AthenaImage");
                    break;
                case "Hermes":
                    speakerImage = Resources.Load<Image>("HermesImage");
                    break;
                case "Eleos":
                    speakerImage = Resources.Load<Image>("EleosImage");
                    break;
            }
            currentLine++;
        }
        else {
            endDialogue();
        }
    }

    public void endDialogue()
    {
        dialogueCanvas.enabled = false;
        Time.timeScale = 1.0f;
        if (nextLevel != -1)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //NextLineButton = GetComponent<Button>();
        //DialogueText = GetComponent<TextMeshProUGUI>();
        dialogueCanvas = GetComponentInChildren<Canvas>();
        dialogueCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // testing dialogue with space bar trigger -- remove for release
        if (Input.GetKeyDown("space"))
            startDialogue("Level 1");
    }
}