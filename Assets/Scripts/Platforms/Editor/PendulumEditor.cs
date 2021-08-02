using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Pendulum))]
public class PendulumEditor : Editor
{
    private Pendulum _pendulum;

    private void Awake()
    {
        _pendulum = target as Pendulum;
    }

    private void OnSceneGUI()
    {
        var xMin = new Vector3(_pendulum.transform.position.x - _pendulum.xRadius, _pendulum.transform.position.y, _pendulum.transform.position.z);
        var xMax = new Vector3(_pendulum.transform.position.x + _pendulum.xRadius, _pendulum.transform.position.y, _pendulum.transform.position.z);
        var yMin = new Vector3(_pendulum.transform.position.x, _pendulum.transform.position.y - _pendulum.yRadius, _pendulum.transform.position.z);

        Handles.DrawBezier(xMin, yMin, xMin + 0.25f * _pendulum.yRadius * Vector3.down, yMin + 0.25f * _pendulum.xRadius * Vector3.left, Color.red, null, 1);
        Handles.DrawBezier(yMin, xMax, yMin + 0.25f * _pendulum.xRadius * Vector3.right, xMax + 0.25f * _pendulum.yRadius * Vector3.down, Color.red, null, 1);
    }
}
