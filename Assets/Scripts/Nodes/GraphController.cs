using System;
using Nodes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

[HideMonoScript]
public class GraphController : Interactable
{
    public Graph graph;

    [Header("UI"), SerializeField] private GameObject outputTextBox = null;
    [AssetsOnly] public GameObject replyPrefab = null;

    [NonSerialized] public GameObject textBoxInstance = null;

    protected override void Action(InputAction.CallbackContext context = default)
    {
        if (!textBoxInstance && graph)
        {
            textBoxInstance = Instantiate(outputTextBox, transform);
            textBoxInstance.SetActive(true);

            graph.Load(this);
        }
    }
}
