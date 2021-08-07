using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GraphControllerOnEnter : MonoBehaviour
{
    [HideLabel] public Nodes.Graph graph;

    protected void OnTriggerEnter(Collider other)
    {
        if (graph && !TextManager.Instance.doc.rootVisualElement.visible)
        {
            graph.Load();
        }
    }
}
