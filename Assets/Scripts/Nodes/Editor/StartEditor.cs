using System.Collections;
using System.Collections.Generic;
using NodeEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

[CustomNodeEditor(typeof(Start))]
public class StartEditor : XNodeEditor.NodeEditor
{
    public override void OnBodyGUI()
    {
        var t = target as Start;
        if (t != null)
        {
            NodeEditorGUILayout.PortField(
                new GUIContent(), t.GetOutputPort("outNode"));
        }
    }
}
