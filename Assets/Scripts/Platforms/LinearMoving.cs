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
    Vector3 baseTransformVector;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (direction == Direction.X)
        {
            baseTransformVector = new Vector3(1, 0, 0);
        }
        else if (direction == Direction.Y)
        {
            baseTransformVector = new Vector3(0, 1, 0);
        }
        else
        {
            baseTransformVector = new Vector3(0, 0, 0);
            Debug.LogError($"No such direction for {gameObject.name}: {direction}");
        }
    }

    private void FixedUpdate()
    {
        Vector3 offset = travelDistance * Mathf.Cos((Mathf.PI / 2) * Time.time * speed) * baseTransformVector;
        transform.position = startPosition + offset;
    }
}
