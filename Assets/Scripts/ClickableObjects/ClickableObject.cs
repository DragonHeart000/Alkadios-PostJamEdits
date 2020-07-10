using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void BreakPower()
    {
        Debug.Log(gameObject.name);
        Debug.Log("BreakPower");
    }

    public virtual void TelekinesisPower()
    {
        Debug.Log(gameObject.name);
        Debug.Log("TelekinesisPower");
    }
}
