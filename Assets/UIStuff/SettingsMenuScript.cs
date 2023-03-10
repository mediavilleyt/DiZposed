using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsMenuScript : MonoBehaviour
{
    public UIDocument document;

    Button backButton;
    VisualElement settingsBack;

    Button fullscreen;
    bool fullscreenState = true;

    Button vSync;
    bool vSyncState = false;

    Button quality;
    Button fps;
    QualityStates qState = QualityStates.High;
    FPSStates fpsState = FPSStates.Off;

    void Start()
    {
        Screen.SetResolution(1920, 1080, fullscreenState);
        fullscreenState = false;
        vSyncState = false;
        qState = QualityStates.Ultra;
        fpsState = FPSStates.State1;

        settingsBack = document.rootVisualElement.Q<VisualElement>("Settings");
        backButton = document.rootVisualElement.Q<Button>("ExitButton");
        fullscreen = document.rootVisualElement.Q<Button>("FullscreenButton");
        vSync = document.rootVisualElement.Q<Button>("VsyncButton");
        quality = document.rootVisualElement.Q<Button>("QualityButton");
        fps = document.rootVisualElement.Q<Button>("FPSButton");
        fullscreen.clicked += FullscreenState;
        vSync.clicked += VsyncState;
        quality.clicked += QualityState;
        fps.clicked += FPSState;
        backButton.clicked += GoBack;

        FullscreenState();
        QualityState();
        FPSState();
    }

    void GoBack()
    {
        settingsBack.visible = false;
    }

    void FullscreenState()
    {
        if (fullscreenState)
        {
            fullscreenState = false; 
            fullscreen.text = " Off";
            Screen.fullScreen = false;
        }
        else
        {
            fullscreenState = true;
            fullscreen.text = " On";
            Screen.fullScreen = true;
        }
    }

    void VsyncState()
    {
        if (vSyncState)
        {
            vSyncState = false;
            vSync.text = " Off";
            QualitySettings.vSyncCount = 0;
        }

        else
        {
            vSyncState = true;
            vSync.text = " On";
            QualitySettings.vSyncCount = 1;
        }
    }

    void QualityState()
    {
        if((int)qState < 3)
        {
            qState++;
            QualitySettings.SetQualityLevel((int)qState);
        }
        else
        {
            qState = 0;
            QualitySettings.SetQualityLevel((int)qState);
        }

        quality.text = " " + qState.ToString();
    }

    void FPSState()
    {
        if((int)fpsState < 3)
        {
            fpsState++;
            fps.text = FPSSwitch(fpsState);
        }

        else
        {
            fpsState = 0;
            fps.text = FPSSwitch(fpsState);
        }
    }

    string FPSSwitch(FPSStates state)
    {
        switch ((int)state)
        {
            case 0:
                Application.targetFrameRate = 300; 
                return " Off";
            case 1:
                Application.targetFrameRate = 30; 
                return " 30";
            case 2:
                Application.targetFrameRate = 60; 
                return " 60";
            case 3:
                Application.targetFrameRate = 120; 
                return " 120";
        }
        return null;
    }
}

enum QualityStates
{
    Low = 0,
    Medium = 1,
    High = 2,
    Ultra = 3
}

enum FPSStates
{
    [Description("Off")]
    Off = 0,
    [Description("30")]
    State1 = 1,
    [Description("60")]
    State2 = 2,
    [Description("120")]
    State3 = 3
}
