using System.IO;
using Sirenix.OdinInspector.Editor;
using System.Linq;
using Audio;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

[CustomEditor(typeof(AudioContainer))]
public class AudioContainerEditor : OdinEditor
{
    protected override void OnEnable()
    {
        var t = target as AudioContainer;
        
        //Create folder if it doesnt exist
        const string sourceFolder = "Clips";
        const string destinationFolder = "Controllers";
        
        if (!AssetDatabase.IsValidFolder(Path.Combine(t.dataLocation, destinationFolder)))
        {
            AssetDatabase.CreateFolder(t.dataLocation, destinationFolder);
        }

        var clips = AssetDatabase.FindAssets($"t:{nameof(AudioClip)}", 
            new[] {Path.Combine(t.dataLocation, sourceFolder)});

        foreach (var clip in clips)
        {
            var path = AssetDatabase.GUIDToAssetPath(clip);
            var audioClip = AssetDatabase.LoadAssetAtPath<AudioClip>(path);
            if (t.data.All(o => o.clip != audioClip))
            {
                var settings = CreateInstance<AudioClipSettings>();
                settings.clip = audioClip;
                settings.name = audioClip.name;
                settings.mixerGroup = AssetDatabase.LoadAssetAtPath<AudioMixerGroup>($"{t.dataLocation}/DefaultMixer.mixer");
                
                AssetDatabase.CreateAsset(settings, $"{t.dataLocation}/{destinationFolder}/{settings.name}.asset");
                t.data.Add(settings);
                
                EditorUtility.SetDirty(this);
            }
        }
        
        for (var i = t.data.Count - 1; i >= 0; i--)
        {
            if (!t.data[i])
            {
                t.data.RemoveAt(i);
            }
        }
    }
}
