using UnityEngine;
using AI;

public class GetNearestTarget : Node
{
    private Transform[] players = new Transform[3];

    private Transform nearestPlayer;

    public Transform NearestPlayer
    {
        get { return nearestPlayer; }
    }
    private void Start()
    {
        var GOs = GameObject.FindGameObjectsWithTag("Player");
        int count = 0;
        for (int i = 0; i < GOs.Length; i++)
        {
            if (GOs[i].name != name)
            {
                
                players[count] = GOs[i].transform;
                count++;
            }
        }
    }
    public override void Execute()
    {
        nearestPlayer = GetNearest(players);
        Debug.Log("GetNearestTarget ");
    }

    private Transform GetNearest(Transform[] players)
    {
        Transform nearest = null;
        float minDist = 100f;
       
        for (int i = 0; i < players.Length; i++)
        {
            Transform current = players[i];
            if ((transform.position - current.position).magnitude < minDist)
            {
                nearest = current;
            }
        }

        return nearest;
    }
}