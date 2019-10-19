using System;
using System.Collections.Generic;
using AI;
using UnityEngine;

public class IsTaggedActorNear : SelectWithOption
{
    private List<PlayerController> playersNear = new List<PlayerController>();
    private Transform tagActor;


    public Transform TagActor {
        get { return tagActor; }
    }
    public override bool Check()
    {
        for (int i = 0; i < playersNear.Count; i++)
        {
            var currentPlayer = playersNear[i];
            if (currentPlayer.IsTagged)
            {
                tagActor = currentPlayer.transform;
                Debug.Log("Enemigo Cerca");
                return true;
                
            }
        }

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersNear.Add(other.GetComponent<PlayerController>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersNear.Remove(other.GetComponent<PlayerController>());
        }
    }
}