using System;
using UnityEngine;

public class HumanController : PlayerController
{
    [SerializeField]
    private LayerMask walkable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GoToLocation(GetLocation());
        }
    }

    public override Vector3 GetLocation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit, walkable) ? hit.point : transform.position;
    }
}