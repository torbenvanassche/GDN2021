using System;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private enum MovementMode { None, Sine };
    [SerializeField] MovementMode movementMode = MovementMode.None;

    private enum EndMode { Cycle, Backtrack };
    [SerializeField] EndMode endMode = EndMode.Backtrack;

    [SerializeField] private float currentInterpolTime;
    public List<Transform> waypoints;
    [SerializeField] private float speed = 1f;
    private int currentWaypointIDX;
    private int targetWaypointIDX;
    private bool isReversed;

    protected void Awake()
    {
        currentWaypointIDX = 0;
        targetWaypointIDX = GetNextWaypointIDX(currentWaypointIDX);
    }

    protected void Update()
    {
        // For each t in [0, 1], we interpolate depending on the MovementMode.
        if (currentInterpolTime <= 1)
        {
            Transform source = waypoints[currentWaypointIDX];
            Transform target = waypoints[targetWaypointIDX];

            switch (movementMode)
            {
                case MovementMode.None:
                    LinearMovement(source, target, currentInterpolTime);
                    break;

                case MovementMode.Sine:
                    CosineDampMovement(source, target, currentInterpolTime);
                    break;

                default:
                    break;
            }

            currentInterpolTime += speed * Time.deltaTime;
        }
        else
        {
            currentWaypointIDX = GetNextWaypointIDX(currentWaypointIDX);


            // If in backtrack mode, we reverse if necessary based on where the currentWaypointIDX is.
            if (endMode == EndMode.Backtrack)
            {
                if (isReversed && currentWaypointIDX == 0)
                {
                    isReversed = false;
                }
                else if (!isReversed && currentWaypointIDX == waypoints.Count - 1)
                {
                    isReversed = true;
                }
            }

            targetWaypointIDX = GetNextWaypointIDX(currentWaypointIDX);
            currentInterpolTime = 0;
        }
    }

    private int GetNextWaypointIDX(int idx)
    {
        // For cycle mode, we can use modulus.
        // For backtrack mode, we need to know if we're reversed to use a "modulus".
        switch (endMode)
        {
            case EndMode.Cycle:
                return (idx + 1) % waypoints.Count;

            case EndMode.Backtrack:
                if (isReversed && idx == 0)
                {
                    return waypoints.Count - 1;
                }
                else if (!isReversed && idx == waypoints.Count - 1)
                {
                    return 0;
                }
                else
                {
                    return isReversed ? idx - 1 : idx + 1;
                }
            default:
                Debug.LogError($"No such MovementMode for {transform.name}");
                return 0;
        }
    }

    private void CosineDampMovement(Transform source, Transform target, float t)
    {
        // Uses a Cosine dampening to interpolate between positions.
        var lengthX = target.position.x - source.position.x;
        var offsetX = lengthX != 0 ? lengthX * Mathf.Cos((Mathf.PI / 2f) * (1 - t)) : 0;

        var lengthY = target.position.y - source.position.y;
        var offsetY = lengthY != 0 ? lengthY * Mathf.Cos((Mathf.PI / 2f) * (1 - t)) : 0;

        var lengthZ = target.position.z - source.position.z;
        var offsetZ = lengthZ != 0 ? lengthZ * Mathf.Cos((Mathf.PI / 2f) * (1 - t)) : 0;

        transform.position = source.position + new Vector3(offsetX, offsetY, offsetZ);
    }

    private void LinearMovement(Transform source, Transform target, float t)
    {
        // LERPs to the next position.
        transform.position = Vector3.Lerp(source.position, target.position, t);
    }

    private void OnDrawGizmos()
    {
        foreach (var waypoint in waypoints)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(waypoint.position, 0.05f);
        }
    }
}

