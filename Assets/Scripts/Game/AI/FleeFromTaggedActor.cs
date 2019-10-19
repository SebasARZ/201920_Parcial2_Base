using AI;
using UnityEngine;
using UnityEngine.AI;

public class FleeFromTaggedActor : Node
{
    private IsTaggedActorNear isTaggedActorNear;
    private NavMeshAgent navMeshAgent;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        isTaggedActorNear = GetComponent<IsTaggedActorNear>();
    }
    public override void Execute()
    {
        Vector3 direccion = (transform.position -   isTaggedActorNear.TagActor.position).normalized;
        navMeshAgent.SetDestination(transform.position + direccion * navMeshAgent.speed * Time.deltaTime*90);
        Debug.Log("FleeFromTaggedActor");
    }
}