using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUIScript : MonoBehaviour
{ 
    public UIDocument document;

    bool gameIsPaused;

    VisualElement pauseScreen;
    VisualElement settingsScreen;
    VisualElement QuitScreen;

    Button settingsButton;
    Button resumeButton;
    Button quitButton;

    void Start()
    {
        pauseScreen = document.rootVisualElement.Q("PauseScreen");
        settingsScreen = document.rootVisualElement.Q("Settings");
        QuitScreen = document.rootVisualElement.Q("QuitScreen");
        resumeButton = document.rootVisualElement.Q<Button>("ResumeButton");
        settingsButton = document.rootVisualElement.Q<Button>("SettingsButton");
        quitButton = document.rootVisualElement.Q<Button>("QuitButton");
        resumeButton.clicked += () => PauseGame(!gameIsPaused);
        settingsButton.clicked += Settings;
        quitButton.clicked += Quit;

        gameIsPaused = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(gameIsPaused);
        }
    }

    void PauseGame(bool isPaused)
    {
        isPaused = !isPaused;

        CD.Instance.PauseGame(CD.PauseTypes.mP, isPaused);
        /*"medium pause means everything will be disabled 
         * for example when settingscreen is enabled*/
        pauseScreen.visible = !isPaused;
    }

    void Settings()
    {
        settingsScreen.visible = true;
    }

    void Quit()
    {
        QuitScreen.visible = true;
    }
}
