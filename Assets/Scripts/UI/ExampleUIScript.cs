using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExampleUIScript : MonoBehaviour
{
    public UIDocument UIDocument;
    Label choiceOne;
    Label choiceTwo;

    void Start()
    {
        VisualElement root = UIDocument.rootVisualElement;
        choiceOne = root.Q<Label>("ChoiceOne");
        choiceTwo = root.Q<Label>("ChoiceTwo");
    }

    // private void OnEnable()
    // {
    //     CircleController.OnChangeText += HandleChangeText;
    // }
    // private void OnDisable()
    // {
    //     CircleController.OnChangeText -= HandleChangeText;
    // }

    private void HandleChangeText()
    {
        choiceOne.text = "Okay, this is different.";
        choiceTwo.text = "Yep, different.";
    }
}