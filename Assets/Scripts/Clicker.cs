using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    /*enum activeSpell
    {
        Break,
        Telekenesis
    }

    activeSpell spell = activeSpell.Break;*/

    public Camera mainCamera;
    bool isDragging = false;
    ClickableObject CO;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
            spell = activeSpell.Break;
        if (Input.GetKeyDown(KeyCode.W))
            spell = activeSpell.Telekenesis;*/

        // Left click down -- telekinesis start
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                CO = hit.collider.gameObject.GetComponent<ClickableObject>();
                if (CO != null)
                {
                    CO.GetComponent<Collider>().enabled = false;
                }
            }
        }
        // Left click up -- telekinesis end
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            CO.GetComponent<Collider>().enabled = true;
        }
        if (isDragging)
        {
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace);
            CO.transform.position = currentPosition;
        }

        // Right click -- breaker
        if (Input.GetMouseButtonUp(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                CO = hit.collider.gameObject.GetComponent<ClickableObject>();
                if (CO != null)
                {
                    CO.BreakPower();
                }
            }
        }
    }
}
