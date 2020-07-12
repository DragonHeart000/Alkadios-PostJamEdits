using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleFill : MonoBehaviour
{
    public MeshRenderer meshRend;

    private bool doIt = false; //Quick and dirty fix, don't do this unless pressed for time in a game jam

    public void OnTriggerEnter(Collider other)
    {
        if (doIt)
        {
            //The only thing that could possibly enter is a rock so no need to check for it. You totally should check for it but GAME JAM
            GameObject.Destroy(other.transform.parent.gameObject); //Kill the rock
            Debug.Log("Why?");
            meshRend.enabled = true;
            TargetHub.instance.surface.BuildNavMesh();
        } else
        {
            //Being inside the terrain triggers a OnTriggerEnter so we just ignore the first one.
            doIt = !doIt;
        }
        
    }
}
