using System.Collections.Generic;
using NodeEditor;
using Nodes;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Character")]
public class CharacterData : SerializedScriptableObject
{
    public Sprite characterImage;
}