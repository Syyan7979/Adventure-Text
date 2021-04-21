using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,14)] [SerializeField] string storyText;
    [TextArea(2, 3)] [SerializeField] string[] choices;
    [SerializeField] State[] nextStates;

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public int ChoicesLen()
    {
        return choices.Length;
    }

    public string[] ReturnChoices()
    {
        return choices;
    }
}
