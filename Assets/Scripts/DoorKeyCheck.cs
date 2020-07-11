using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var MCS = other.GetComponent<MainCharacterScript>();
        if (MCS != null && other.CompareTag("Player"))
        {
            if (MCS.CheckForKey())
            {
                Debug.Log("OpenDoor");
                // call open door anim
            }
        }
    }
}
