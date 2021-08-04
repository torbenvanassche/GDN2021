using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingPlatform : MonoBehaviour
{
    private enum MovementMode
    {
        None,
        Sine
    };

    private enum EndMode
    {
        Cycle,
        Backtrack
    };

    [SerializeField] EndMode endMode = EndMode.Backtrack;
    [SerializeField] MovementMode movementMode = MovementMode.None;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject _target;

    [Button]
    private void SetToFirst()
    {
        if(_target && waypoints.Count > 0) _target.transform.position = transform.position + waypoints[0];
    }

    private float currentInterpolTime;
    private int currentWaypointIDX;
    private int targetWaypointIDX;
    private bool isReversed;

    [SerializeField] private List<Vector3> waypoints;

    protected void Awake()
    {
        currentWaypointIDX = 0;
        targetWaypointIDX = GetNextWaypointIDX();
    }

    protected void Update()
    {
        // For each t in [0, 1], we interpolate depending on the MovementMode.
        if (currentInterpolTime <= 1)
        {
            Vector3 source = waypoints[currentWaypointIDX];
            Vector3 target = waypoints[targetWaypointIDX];

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
            currentWaypointIDX = GetNextWaypointIDX();


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

            targetWaypointIDX = GetNextWaypointIDX();
            currentInterpolTime = 0;
        }
    }

    private int GetNextWaypointIDX()
    {
        // For cycle mode, we can use modulus.
        // For backtrack mode, we need to know if we're reversed to use a "modulus".
        switch (endMode)
        {
            case EndMode.Cycle:
                return (currentWaypointIDX + 1) % waypoints.Count;

            case EndMode.Backtrack:
                if (isReversed && currentWaypointIDX == 0)
                {
                    return waypoints.Count - 1;
                }
                else if (!isReversed && currentWaypointIDX == waypoints.Count - 1)
                {
                    return 0;
                }
                else
                {
                    return isReversed ? currentWaypointIDX - 1 : currentWaypointIDX + 1;
                }
            default:
                return 0;
        }
    }

    private void CosineDampMovement(Vector3 source, Vector3 target, float t)
    {
        // Uses a Cosine dampening to interpolate between positions.
        var lengthX = target.x - source.x;
        var offsetX = lengthX != 0 ? lengthX * Mathf.Cos((Mathf.PI / 2f) * (1 - t)) : 0;

        var lengthY = target.y - source.y;
        var offsetY = lengthY != 0 ? lengthY * Mathf.Cos((Mathf.PI / 2f) * (1 - t)) : 0;

        var lengthZ = target.z - source.z;
        var offsetZ = lengthZ != 0 ? lengthZ * Mathf.Cos((Mathf.PI / 2f) * (1 - t)) : 0;

        _target.transform.position = transform.position + source + new Vector3(offsetX, offsetY, offsetZ);
    }

    private void LinearMovement(Vector3 source, Vector3 target, float t)
    {
        // LERPs to the next position.
        _target.transform.position = Vector3.Lerp(transform.position + source, target, t);
    }

    private void OnDrawGizmosSelected()
    {
        for (var index = 0; index < waypoints.Count - 1; index++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + waypoints[index], transform.position + waypoints[index + 1]);
        }
        
        foreach (var waypoint in waypoints)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + waypoint, 0.05f);
        }
    }
}