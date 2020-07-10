using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHub : MonoBehaviour
{
    public static TargetHub instance;

    public Object[] targets;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        //This should be destroyed on load though as the one in the next level will take over.
    }

    // Start is called before the first frame update
    void Start()
    {
        targets = FindObjectsOfType(typeof(Target));
        Debug.Log(targets.Length + " targets found.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
