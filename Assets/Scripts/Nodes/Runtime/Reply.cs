using System.Threading.Tasks;
using Nodes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using XNode;

namespace NodeEditor
{
    public sealed class Reply : State
    {
        [HideLabel, Multiline(3)] public string text;
        [HideInInspector] public GameObject button = null;

        private new State GetNext()
        {
            State outNode = null;
            
            foreach (var node in GetOutputNodes())
            {
                if (node.GetType().BaseType == typeof(Conditional))
                {
                    return node.GetNext();
                }
                
                if(!outNode) outNode = node;
            }

            return outNode;
        }

        public override async Task<State> OnEnter()
        {
            await base.OnEnter();
            return this;
        }

        public override void OnCreateConnection(NodePort from, NodePort to)
        {
            if (to.node.GetType() == from.node.GetType())
            {
                to.Disconnect(from);
            }
        }

        public void GenerateButton()
        {
            button = Instantiate(Graph.Controller.replyPrefab, 
                Text.OutputField.transform.parent.GetComponentInChildren<VerticalLayoutGroup>().transform);

            button.GetComponentInChildren<UnityEngine.UI.Text>().text = text;
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                Graph.CurrentNode = GetNext();
            });
        }
    }
}
