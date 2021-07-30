using NodeEditor;

namespace Nodes
{
    [NodeWidth(370),DontFold, NodeTint(90, 90, 150)]
    public abstract class Function : State
    {
        public override State GetNext()
        {
            return null;
        }
    }
}
