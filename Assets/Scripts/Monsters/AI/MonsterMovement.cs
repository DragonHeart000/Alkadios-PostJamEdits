using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
    public List<MonsterTargetLocation> targets;

    private NavMeshSurface surface;
    public NavMeshAgent agent;

    //bool to stop it's standard rutine if the character is near
    private bool chasing = false;

    //This can be changed to make the monster see further
    public float maxRange = 50;

    private GameObject player;

    //There should be an empty game object that contains all the targets for each specific monster
    public GameObject targetsContainer;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in targetsContainer.transform)
        {
            if (child.GetComponent<MonsterTargetLocation>() != null)
            {
                targets.Add(child.GetComponent<MonsterTargetLocation>());
            }
        }

        player = GameObject.FindGameObjectWithTag("Player");
        surface = TargetHub.instance.surface;
    }

    // Update is called once per frame
    void Update()
    {
        if (!chasing)
        {
            if (agent.remainingDistance <= 0.2)
            {
                changeTillValidTarget();
            }
        } else
        {
            changeTarget(player.transform.position);
        }

        RaycastHit hit;
        if (Vector3.Distance(transform.position, player.transform.position) < maxRange)
        {
            if (Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit, maxRange))
            {
                if (hit.transform == player.transform)
                {
                    //Player is in range and can be seen.
                    chasing = true;
                } else
                {
                    chasing = false;
                }
            }
        } else
        {
            chasing = false;
        }
    }

    public void changeTillValidTarget()
    {
        if (!changeTarget())
        {
            changeTillValidTarget();
        }
    }

    public MonsterTargetLocation getRandom()
    {
        return targets[Random.Range(0, targets.Count)];
    }

    //Change target will pick a random target to go to. Returns true if path is valid and false if it can not get there
    public bool changeTarget()
    {
        return changeTarget(getRandom().transform.position);
    }

    //Change target vector3 will set the destination to a specific location. Returns true if path is valid and false if it can not get there
    public bool changeTarget(Vector3 newDestination)
    {
        NavMeshPath path = new NavMeshPath();
        agent.destination = newDestination;
        agent.CalculatePath(newDestination, path);

        if (path.status == NavMeshPathStatus.PathPartial || path.status == NavMeshPathStatus.PathInvalid)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}
