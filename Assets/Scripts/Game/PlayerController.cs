using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]

public abstract class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float stopTime = 3F;

    protected NavMeshAgent agent { get; set; }

    public bool IsTagged { get;  set; }

    public void SwitchRoles()
    {
        IsTagged = !IsTagged;
        // Pause all logic and restart after
    }

    public void GoToLocation(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public virtual IEnumerator StopLogic()
    {
        // Stop BT runner if AI player, else stop movement.
        agent.isStopped = true;

        yield return new WaitForSeconds(stopTime);

        agent.isStopped = false;
        // Restart stuff.
    }

    public abstract Vector3 GetLocation();

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        SwitchRoles();

        if (IsTagged)
        {
            Debug.Log($"{name} {IsTagged}");
            StartCoroutine(StopLogic());
            GameController.Instance.OnPlayerStateChange(name);
        }
    }
}