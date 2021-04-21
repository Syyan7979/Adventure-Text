using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    // Config params
    [SerializeField] State introText;
    [SerializeField] Text textField;

    // Cached Reference
    AdventurText mainScript;

    private void Start()
    {
        mainScript = FindObjectOfType<AdventurText>();
    }

    public void QuitPressed()
    {
        mainScript.currentState = introText;
        textField.text = introText.GetStateStory();
        mainScript.startButton.gameObject.SetActive(true);
    }
}
