using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using XNode;
using XNode.Odin;

namespace Nodes
{
    [Serializable] public class Empty {}

    [DontFold] public abstract class State : Node
    {
        [Input, HorizontalGroup("transition"), HideLabel, HandleOnly] public Empty inNode;
        [Output, HorizontalGroup("transition"), HideLabel, HandleOnly] public Empty outNode;
        
        protected Graph Graph
        {
            get => graph as Graph;
            set => graph = value;
        }

        protected IEnumerable<State> GetOutputNodes()
        {
            var connections = GetPort(nameof(outNode)).GetConnections()
                .Select(nodePort => nodePort.node as State);
            return connections;
        }

        public override object GetValue(NodePort port)
        {
            return port.node.name;
        }

        public virtual async Task<State> OnEnter()
        {
            foreach (var functionNode in GetOutputNodes().OfType<Function>())
            {
                await functionNode.OnEnter();
            }

            return this;
        }

        public virtual State GetNext()
        {
            var nodes = GetOutputNodes();

            if (!nodes.Any())
            {
                Graph.Unload();
            }
            
            return null;
        }
    }
}