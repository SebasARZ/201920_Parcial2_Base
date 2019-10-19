using AI;
using UnityEngine.AI;
using UnityEngine;

public class FollowTarget : Node
{
    AIController aIController;
    
    private void Start()
    { 
        aIController = GetComponent<AIController>();
    }
    public override void Execute()
    {
        aIController.Target = aIController.GetLocation();
        aIController.GoToLocation(aIController.Target);
        Debug.Log("FollowTarget");
    }
}