using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class MenuEvent : UnityEvent { }

public class MenuButtonUI : MonoBehaviour
{
    public string buttonText;
    public MenuEvent buttonEvent;

    public Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        uiText.text = buttonText;
    }

    public void OnClick()
    {
        buttonEvent.Invoke();
    }
}
