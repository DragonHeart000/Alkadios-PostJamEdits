﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scanForPause();
    }

    void scanForPause()
    {
        if (Input.GetKeyDown("escape"))
            GM.TogglePauseMenu();
    }
}
