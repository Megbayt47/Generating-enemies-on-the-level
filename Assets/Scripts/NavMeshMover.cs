using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMover : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Target _target;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.destination = _target.transform.position;
    }

    public void GetTarget(Target target)
    {
        _target = target;
    }
}
