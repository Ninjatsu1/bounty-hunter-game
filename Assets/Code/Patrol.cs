using UnityEngine;
using UnityEngine.AI;
public class Patrol : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    private int destinationPoint = 0;
    private NavMeshAgent agent;
    [SerializeField]
    private float minRemainigDistance = 0.5f;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
    }
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < minRemainigDistance)
        {
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        if(waypoints.Length == 0)
        {
            Debug.Log("You must add at least one destination point");
            return;
        }
        agent.destination = waypoints[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % waypoints.Length;
    }


}
