using System;
using System.Linq;
using Nodes;

namespace NodeEditor
{
    [NodeWidth(70), DontFold]
    public class Start : State
    {
        public override State GetNext()
        {
            base.GetNext();
            
            var nodes = GetOutputNodes().ToList();
            return nodes.FirstOrDefault();
        }
    }
}
