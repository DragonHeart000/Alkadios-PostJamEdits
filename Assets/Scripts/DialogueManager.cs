using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    string path = "Assets/Resources/testscript.txt";
    StreamReader sr;
    Text DialogueText;
    Image NextLineButton;

    public void startDialogue()
    {
        if (!File.Exists(path))
        {
            Debug.Log("File doesn't exist, cannot read");
            return;
        }

        sr = new StreamReader(path);
        DialogueText.text = sr.ReadLine();
    }

    public void nextLine()
    {
        DialogueText.text = sr.ReadLine();
    }

    // Start is called before the first frame update
    void Start()
    {
        NextLineButton = GetComponent<Image>();
        DialogueText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
