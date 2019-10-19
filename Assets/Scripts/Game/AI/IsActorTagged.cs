using AI;
using UnityEngine;
public class IsActorTagged : SelectWithOption
{
    [SerializeField] private PlayerController playerController;
    public override bool Check()
    {
        return playerController.IsTagged;
    }
    private void Awake()
    {
        if(playerController == null)
        {
            playerController = GetComponent<PlayerController>();
        }
    }
}
