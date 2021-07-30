using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using System.Linq;

[HideMonoScript]
public abstract class ListContainer<T> : ScriptableObject where T : ScriptableObject
{
    [FolderPath] public string dataLocation;

    [SerializeField, ListDrawerSettings(Expanded = true)] public List<T> data = new List<T>();

    public T Get(string value)
    {
        return data.FirstOrDefault(item => item.name == value);
    }
}
