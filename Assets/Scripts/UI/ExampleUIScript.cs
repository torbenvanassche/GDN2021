using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExampleUIScript : MonoBehaviour
{
    Label choiceOne;
    Label choiceTwo;
    VisualElement characterPortraitBox;
    public Texture2D Character1;
    public Texture2D Character2;

    void Awake()
    {
        // The root allows us to Query ("Q") elements using things like their name (which is the default).  Similar to JQuery.
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        choiceOne = root.Q<Label>("ChoiceOne");
        choiceTwo = root.Q<Label>("ChoiceTwo");
        characterPortraitBox = root.Q<VisualElement>("CharacterPortrait");

    }

    void Start()
    {
        choiceOne.text = "Okay, this is different.";
        choiceTwo.text = "Yep, different.";

        // Currently required to change images like this, see: https://forum.unity.com/threads/how-to-displays-rawimage-in-the-uitoolkit.989257/
        // Moreover, they must be in StyleBackground format which takes, among other things, a Texture2D.
        characterPortraitBox.style.backgroundImage = new StyleBackground(Character2);
    }
}