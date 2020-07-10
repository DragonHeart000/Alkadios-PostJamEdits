using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class TreeClickableObject : ClickableObject
{
    public bool Fallen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void BreakPower()
    {
        base.BreakPower();
        Destroy(gameObject);
    }

    public override void TelekinesisPower()
    {
        if (!Fallen)
        {
            base.TelekinesisPower();
            gameObject.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
            Fallen = true;
        }
    }
}
