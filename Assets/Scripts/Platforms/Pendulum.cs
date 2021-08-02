using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{

    [SerializeField] float xRadius = 4f;
    [SerializeField] float yRadius = 2f;
    [SerializeField] float speed = 0.25f;
    private float currentInterpolTime = 0.0f;

    private void Update()
    {
        currentInterpolTime = Time.time * speed % 1f;

        // Sin-interpolate for X and Y for "bobbing" movements in both directions.
        // Y moves at double speed: it must bob up on the left and bob up on the right.
        float x = xRadius * Mathf.Cos(2 * Mathf.PI * currentInterpolTime);
        float y = -yRadius * Mathf.Pow(Mathf.Sin(-2 * Mathf.PI * currentInterpolTime), 2);

        transform.localPosition = new Vector3(x, y, 0);
    }
}
