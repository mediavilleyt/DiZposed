using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    public UIDocument document;
    Button playButton;
    Button settingsButton;
    Button quitButton;

    VisualElement settingsBack;
    VisualElement gunSelect;

    void Start()
    {
        playButton = document.rootVisualElement.Q<Button>("PlayButton");
        playButton.clicked += StartGame;
        quitButton = document.rootVisualElement.Q<Button>("QuitButton");
        quitButton.clicked += QuitGame;
        settingsButton = document.rootVisualElement.Q<Button>("SettingsButton");
        settingsButton.clicked += SettingsMenu;
        settingsBack = document.rootVisualElement.Q<VisualElement>("Settings");
        settingsBack.visible = false;
        gunSelect = document.rootVisualElement.Q<VisualElement>("Select");
        gunSelect.visible = false;
    }

    void StartGame()
    {
        gunSelect.visible = true;
    }
   
    void QuitGame()
    {
        Application.Quit();
    }

    void SettingsMenu()
    {
        settingsBack.visible = true;
    }
}
