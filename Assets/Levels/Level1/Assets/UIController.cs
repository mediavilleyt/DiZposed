using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    VisualElement root;
    Label txt;
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement; //get the root
        txt = root.Q<Label>("AmmoCounter"); //connect the labels
    }

    private void Update()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        txt.text = CD.Instance.clip + "|" + CD.Instance.ammo;
    }
}
