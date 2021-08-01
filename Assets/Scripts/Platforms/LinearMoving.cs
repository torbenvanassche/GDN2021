using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMoving : MonoBehaviour
{
    public enum Direction { X, Y }
    public Direction direction = Direction.X;
    public float travelDistance = 1;
    public float speed = 1f;
    private Vector3 startPosition;
    Vector3 movementDirection;

    void Start()
    {
        startPosition = transform.position;
        movementDirection = GetMovementDirection();
    }


    private Vector3 GetMovementDirection()
    //  Get Vector3 to act as an axis for the object to move along.
    {
        switch (direction)
        {
            case Direction.X:
                return new Vector3(1, 0, 0);
            case Direction.Y:
                return new Vector3(0, 1, 0);
            default:
                Debug.LogError($"No such direction for {gameObject.name}: {direction}");
                return new Vector3(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        Vector3 offset = movementDirection * travelDistance * Mathf.Cos((Mathf.PI / 2) * Time.time * speed);
        transform.position = startPosition + offset;
    }
}
