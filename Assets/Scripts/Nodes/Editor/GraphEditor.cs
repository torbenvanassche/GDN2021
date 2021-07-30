using System;
using Nodes;
using UnityEngine;
using XNodeEditor;

namespace NodeEditor.Editor
{
    [CustomNodeGraphEditor(typeof(Graph))]
    public class GraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(Type type)
        {
            if (type == typeof(Start)) return null;

            return type.BaseType == typeof(Function) || type.BaseType == typeof(Conditional)
                ? UnityEditor.ObjectNames.NicifyVariableName($"{type.BaseType.Name}/{type.Name}")
                : UnityEditor.ObjectNames.NicifyVariableName($"{type.Name}");
        }
    }
}
