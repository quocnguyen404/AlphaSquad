using System;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [Header("Configuration")]
    public float moveSpeed = 3f;
    public float angularSpeed = 10f;

    [Header("Debuger")]
    public bool showPath = true;


    private NavMeshAgent _agent = null;
    public NavMeshAgent AgentBody => this.TryGetMonoComponent(ref _agent);

    private NavMeshPath path = null;


    public Action OnArried = null;


    public void Initialized()
    {
        path = new NavMeshPath();
    }

    public void SetDestination(Vector3 destination)
    {
        AgentBody.isStopped = false;
        AgentBody.SetDestination(destination);
        if (Vector3.Distance(transform.position, destination) <= AgentBody.radius)
            OnArried?.Invoke();
    }


    public void MoveToDestination(Vector3 destination)
    {
        Vector3 dir = destination - transform.position;
        dir.y = transform.forward.y;
        MoveToDirection(dir);
        showPath = NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path);
        if (Vector3.Distance(transform.position, destination) <= AgentBody.radius)
            OnArried?.Invoke();
    }


    public void MoveToDirection(Vector3 direction)
    {
        RotateToDirection(direction);
        AgentBody.Move(transform.forward * moveSpeed * Time.deltaTime);
    }


    public void RotateToDirection(Vector3 direction)
    {
        Quaternion targetQuaternion = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, angularSpeed * Time.deltaTime);
    }


    private void OnDrawGizmos()
    {
        if (!showPath || path == null)
            return;

        Gizmos.color = Color.blue;
        for (int i = 1; i < path.corners.Length; i++)
        {
            Gizmos.DrawCube(path.corners[i - 1], Vector3.one * 0.2f);
            Gizmos.DrawLine(path.corners[i - 1], path.corners[i]);
        }
    }
}
