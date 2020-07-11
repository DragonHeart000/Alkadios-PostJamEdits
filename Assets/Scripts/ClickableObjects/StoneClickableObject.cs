using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneClickableObject : ClickableObject
{

    bool IsBeingDraged = false;
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBeingDraged)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                gameObject.transform.position = hit.point;
            }
        }
    }

    public override void BreakPower()
    {
        base.BreakPower();
        Destroy(gameObject);
    }

    public override void StartTelekinesisPower(Camera camera)
    {
        base.StartTelekinesisPower(camera);
        this.mainCamera = camera;
        IsBeingDraged = true;
        gameObject.GetComponent<Collider>().enabled = false;
    }

    public override void StopTelekinesisPower()
    {
        base.StopTelekinesisPower();
        IsBeingDraged = false;
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
