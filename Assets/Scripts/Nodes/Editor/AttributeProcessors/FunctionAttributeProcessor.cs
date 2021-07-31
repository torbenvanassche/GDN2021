using System;
using System.Collections.Generic;
using System.Reflection;
using NodeEditor;
using Nodes;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

public class FunctionAttributeProcessor<T> : OdinAttributeProcessor<T> where T : Function
{
    public override void ProcessChildMemberAttributes(InspectorProperty parentProperty, MemberInfo member, List<Attribute> attributes)
    {
        if (member.Name == "outNode")
        {
            attributes.Clear();
            attributes.Add(new HideInInspector());
        }
    }
}
