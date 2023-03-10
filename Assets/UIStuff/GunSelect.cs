using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GunSelect : MonoBehaviour
{
    public string levelName;
    public UIDocument document;

    Button rifleButton;
    Button shotgunButton;

    void Start()
    {
        rifleButton = document.rootVisualElement.Q<Button>("RifleButton");
        rifleButton.clicked += () => LoadGame(0);
        shotgunButton = document.rootVisualElement.Q<Button>("ShotgunButton");
        shotgunButton.clicked += () => LoadGame(1);
    }

    void LoadGame(int wpInt)
    {
        CD.Instance.primaryInt = wpInt;
        SceneManager.LoadSceneAsync(levelName);
    }
}
