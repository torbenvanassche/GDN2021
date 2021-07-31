using Nodes;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

public class GraphController : Interactable
{
    [HideLabel] public Graph graph;

    protected override void Action(InputAction.CallbackContext context = default)
    {
        if (graph)
        {
            graph.Load();
        }
    }
}
