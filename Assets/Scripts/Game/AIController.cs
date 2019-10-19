using System;
using AI;
using UnityEngine;

[RequireComponent(typeof(BehaviourRunner))]
public class AIController : PlayerController
{
    [SerializeField] private GetNearestTarget getNearestTarget;

    private Vector3 target;
    
    public Vector3 Target
    {
        get { return target; }
        set { target = value; }
    }
    private void Awake()
    {
        if (getNearestTarget == null) getNearestTarget = GetComponent<GetNearestTarget>();
    }

    public override Vector3 GetLocation()
    {
        return IsTagged ? getNearestTarget.NearestPlayer.position : target;
    }
}