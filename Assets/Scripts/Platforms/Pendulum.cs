using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Pendulum : MonoBehaviour
{

    public float xRadius = 4f;
    public float yRadius = 2f;
    [SerializeField] float speed = 0.25f;
    [SerializeField] private GameObject target;
    
    private float currentInterpolTime = 0.0f;

    private void Update()
    {
        currentInterpolTime = Time.time * speed % 1f;

        // Sin-interpolate for X and Y for "bobbing" movements in both directions.
        // Y moves at double speed: it must bob up on the left and bob up on the right.
        float x = xRadius * Mathf.Cos(2 * Mathf.PI * currentInterpolTime);
        float y = -yRadius * Mathf.Pow(Mathf.Sin(-2 * Mathf.PI * currentInterpolTime), 2);

        target.transform.localPosition = new Vector3(x, y, 0);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(transform.position.x - xRadius, transform.position.y, transform.position.z), 0.05f);
        Gizmos.DrawSphere(new Vector3(transform.position.x + xRadius, transform.position.y, transform.position.z), 0.05f);
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - yRadius, transform.position.z), 0.05f);
    }
}
