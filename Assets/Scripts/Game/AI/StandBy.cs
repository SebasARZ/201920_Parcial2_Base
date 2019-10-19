using System;
using AI;
using UnityEngine;
using UnityEngine.Animations;

public class StandBy : Node
{
    [SerializeField] private AIController aiController;

    private void Awake()
    {
        if (aiController == null) aiController = GetComponent<AIController>();
    }

    public override void Execute()
    {
        aiController.Target = transform.position;
        aiController.GoToLocation(aiController.GetLocation());
        Debug.Log("StandBy");
    }
}