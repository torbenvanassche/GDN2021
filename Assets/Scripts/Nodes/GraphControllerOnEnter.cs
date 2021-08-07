using Nodes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class GraphControllerOnEnter : MonoBehaviour
{
    [HideLabel] public Graph graph;

    protected void OnTriggerEnter(Collider other)
    {
        if (graph && !TextManager.Instance.doc.rootVisualElement.visible)
        {
            graph.Load();
        }
    }
}
