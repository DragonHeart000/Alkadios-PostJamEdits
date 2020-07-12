using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
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
        // Left click down -- telekinesis start
        if (Input.GetMouseButtonDown(0) && !UIManager.isPaused)
        {
            isDragging = true;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                CO = hit.collider.gameObject.GetComponent<ClickableObject>();
                if (CO != null)
                {
                    CO.StartTelekinesisPower(mainCamera);
                }
            }
        }
        // Left click up -- telekinesis end
        if (Input.GetMouseButtonUp(0) && !UIManager.isPaused)
        {
            isDragging = false;
            if (CO != null)
            {
                CO.StopTelekinesisPower();
                CO = null;
            }
        }

        // Right click -- breaker
        if (Input.GetMouseButtonUp(1) && !isDragging && !UIManager.isPaused)
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
            CO = null;
        }
    }
}
