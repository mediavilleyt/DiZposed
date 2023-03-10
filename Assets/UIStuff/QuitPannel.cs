using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class QuitPannelUI : MonoBehaviour
{
    public UIDocument document;

    VisualElement quitScreen;

    Button menuButton;
    Button desktopButton;
    Button backButton;


    // Start is called before the first frame update
    void Start()
    {
        quitScreen = document.rootVisualElement.Q("QuitScreen");
        menuButton = document.rootVisualElement.Q<Button>("ToMenu");
        desktopButton = document.rootVisualElement.Q<Button>("ToDesktop");
        backButton = document.rootVisualElement.Q<Button>("ToBack");
        menuButton.clicked += Menu;
        desktopButton.clicked += Desktop;
        backButton.clicked += Back;
    }

    void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Desktop()
    {
        Application.Quit();
    }

    void Back()
    {
        quitScreen.visible = false;
    }
}
