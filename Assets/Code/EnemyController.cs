using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    public bool isAttacking = false;
    [SerializeField]
    private Transform[] waypoints;
    private int destinationPoint = 0;
    [SerializeField]
    private float minRemainingDistance = 1f;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Patrol();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (!agent.pathPending && agent.remainingDistance < minRemainingDistance)
        {
            Patrol();
        }
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                Attack();
                FaceTarget();
                isAttacking = true;
            }
            if (distance >= lookRadius)
            {
                isAttacking = false;
                animator.SetBool("hit", false);
                Patrol();
            }
        }
    }

    //Attack the target
    //TO DO: Do damage
    void Attack()
    {
        if(isAttacking)
        {
            animator.SetBool("hit", true);
        }
    }

    void Patrol()
    {
        if (waypoints.Length == 0)
        {
            Debug.Log("You must add at least one waypoint");
            return;
        }
        agent.destination = waypoints[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % waypoints.Length;
    }

    //Face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    //Display look radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
