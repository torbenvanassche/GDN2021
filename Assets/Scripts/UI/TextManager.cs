using System.Collections.Generic;
using NodeEditor;
using Nodes;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;
using Utils;

public class TextManager : Singleton<TextManager>
{
    private VisualElement root;
    public UIDocument doc;

    VisualElement characterPortraitBox;
    private TextElement textBox;
    private VisualElement replies;
    private Label characterName;

    [SerializeField] private int printSpeed = 10;
    private Printer _printer;

    void Awake()
    {
        // The root allows us to Query ("Q") elements using things like their name (which is the default).  Similar to JQuery.
        root = doc.rootVisualElement;
        replies = root.Q<VisualElement>("RepliesDiv");
        textBox = root.Q<Label>("Text");
        characterName = root.Q<Label>("CharacterName");

        characterPortraitBox = root.Q<VisualElement>("CharacterPortrait");

        _printer = gameObject.AddComponent<Printer>();
        _printer.Initialize(textBox, printSpeed);
        
        doc.rootVisualElement.visible = false;
    }

    public async void UpdateUI(CharacterData _character, string _toPrint, List<Reply> _replies)
    {
        // Currently required to change images like this, see: https://forum.unity.com/threads/how-to-displays-rawimage-in-the-uitoolkit.989257/
        // Moreover, they must be in StyleBackground format which takes, among other things, a Texture2D.
        characterPortraitBox.style.backgroundImage = new StyleBackground(_character.characterImage);
        characterName.text = _character.name;
        
        //await printer finish to show reply buttons
        await _printer.Print(_toPrint, true);

        foreach (var reply in _replies)
        {
            if (!reply) return; 
            
            var button = new Button(() =>
            {
                //handle graph progression
                (reply.graph as Graph).CurrentNode = reply.GetNext();

                //reverse to prevent going out of range, remove all buttons
                for (int i = replies.childCount - 1; i >= 0; i--)
                {
                    replies.RemoveAt(i);
                }
            });

            button.text = reply.text;
            button.style.width = new Length(50, LengthUnit.Percent);
            replies.Add(button);
        }
    }

    public void Next()
    {
        var text = Manager.Instance.activeGraph.CurrentNode.GetNext() as Text;
        if (text)
        {
            Manager.Instance.activeGraph.CurrentNode = text;
        }
        else
        {
            Manager.Instance.activeGraph.Unload();
        }
    }
}