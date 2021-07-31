using System.Threading.Tasks;
using Nodes;
using Sirenix.OdinInspector;
using UnityEngine;
using XNode;

namespace NodeEditor
{
    public sealed class Reply : State
    {
        [HideLabel, Multiline(3)] public string text;

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
    }
}
