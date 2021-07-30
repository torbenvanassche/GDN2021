using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Nodes
{
    public class ChangeGraph : Function
    {
        [SerializeField, HideLabel] private Graph nextGraph = null;
    
        public override Task<State> OnEnter()
        {
            Graph.graphOnReset = nextGraph;
            return Task.FromResult(this as State);
        }
    }
}
