using System;
using Nodes;
using UnityEngine;
using Utilities;

public class Manager : Singleton<Manager>
{
    public new Camera camera = null;
    public SidescrollerController player = null;
    [NonSerialized] public Graph activeGraph = null;

    private void Reset()
    {
        if (!camera)
        {
            camera = Camera.main;
        }

        if (!player)
        {
            player = FindObjectOfType<SidescrollerController>();
        }
    }
}
