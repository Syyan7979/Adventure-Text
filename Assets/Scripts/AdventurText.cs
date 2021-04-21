using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurText : MonoBehaviour
{
    // Config params
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] Text buttonOneText;
    [SerializeField] Text buttonTwoText;
    [SerializeField] Button buttonOne;
    [SerializeField] Button buttonTwo;
    [SerializeField] public Button startButton;
    [SerializeField] Button tryAgainButton;

    // States
    public State currentState;
    Vector2 buttoneOnePos;
    Vector2 subtract = new Vector2(0, 30);

    // Start is called before the first frame update
    void Start()
    {
        currentState = startingState;
        textComponent.text = currentState.GetStateStory();
        buttoneOnePos = buttonOne.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SizeCheck();
        if (currentState.name == "X1. Game Over")
        {
            tryAgainButton.gameObject.SetActive(true);
        } else
        {
            tryAgainButton.gameObject.SetActive(false);
        }
    }

    private void SizeCheck()
    {
        if (currentState.ChoicesLen() == 2)
        {
            buttonOne.gameObject.SetActive(true);
            buttonTwo.gameObject.SetActive(true);
            buttonOne.transform.position = buttoneOnePos;
        }
        else if (currentState.ChoicesLen() == 1)
        {
            buttonTwo.gameObject.SetActive(false);
            buttonOne.transform.position = buttoneOnePos - subtract;
        }
        else if (currentState.ChoicesLen() == 0)
        {
            buttonOne.gameObject.SetActive(false);
            buttonTwo.gameObject.SetActive(false);
        }
    }

    public void ButtonOnePressed()
    {

        OnPressed(1);
    }

    public void ButtonTwoPressed()
    {
        OnPressed(2);
    }

    public void OnPressed(int position)
    {
        var nextStates = currentState.GetNextStates();
        currentState = nextStates[position];
        textComponent.text = currentState.GetStateStory();
        if (currentState.ChoicesLen() == 2)
        {
            buttonTwoText.text = currentState.ReturnChoices()[1];
        }
        if (currentState.ChoicesLen() >= 1)
        {
            buttonOneText.text = currentState.ReturnChoices()[0];
        }
    }

    public void StartButtonPressed()
    {
        OnPressed(1);
        startButton.gameObject.SetActive(false);
    }
}
