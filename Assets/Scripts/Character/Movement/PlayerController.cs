using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeTarget()
    {
        changeTarget(TargetHub.instance.getRandom().gameObject.transform.position);
    }

    public void changeTarget(Vector3 newDestination)
    {
        agent.SetDestination(newDestination);
    }
}
