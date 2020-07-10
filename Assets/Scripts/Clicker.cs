using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    enum activeSpell
    {
        None,
        Break,
        Telekenesis
    }

    activeSpell spell = activeSpell.None;

    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            spell = activeSpell.Break;
        if (Input.GetKeyDown(KeyCode.W))
            spell = activeSpell.Telekenesis;
        if (Input.GetKeyDown(KeyCode.Escape))
            spell = activeSpell.None;


        if (Input.GetMouseButtonDown(0) && spell != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (spell == activeSpell.Break)
                {
                    var CO = hit.collider.gameObject.GetComponent<ClickableObject>();
                    if (CO != null)
                    {
                        CO.BreakPower();
                        spell = 0;
                    }

                }  
                else if (spell == activeSpell.Telekenesis)
                {
                    var CO = hit.collider.gameObject.GetComponent<ClickableObject>();
                    if (CO != null)
                    {

                        CO.TelekinesisPower();
                        spell = 0;
                    }
                }
                
            }
        }
    }
}
