using System.Linq;
using Nodes;

namespace NodeEditor
{
    [NodeTint(143, 0, 0)]
    public abstract class Conditional : State
    {
        public override State GetNext()
        {
            foreach (var node in GetOutputNodes())
            {
                if (node.GetType().BaseType == typeof(Conditional)) return node.GetNext();
                
#pragma warning disable 4014
                node.OnEnter();
#pragma warning restore 4014
                return node;
            }

            return null;
        }
    }
}
