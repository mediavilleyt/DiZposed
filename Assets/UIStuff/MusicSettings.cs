using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UIElements;

public class MusicSettings : MonoBehaviour
{
    public UIDocument document;

    public AudioMixer mainMixer;

    Button musicMinButton;
    Button musicPlusButton;
    Label musicLabel;

    Button effectsMinButton;
    Button effectsPlusButton;
    Label effectsLabel;

    float musicValue = 1;
    float effectsValue = 1;

    void Start()
    {
        musicMinButton = document.rootVisualElement.Q<Button>("MusicMinButton");
        musicMinButton.clicked += MusicMinButton;
        musicPlusButton = document.rootVisualElement.Q<Button>("MusicPlusButton");
        musicPlusButton.clicked += MusicPlusButton;
        musicLabel = document.rootVisualElement.Q<Label>("MusicLabel");

        effectsMinButton = document.rootVisualElement.Q<Button>("EffectsMinButton");
        effectsMinButton.clicked += EffectsMinButton;
        effectsPlusButton = document.rootVisualElement.Q<Button>("EffectsPlusButton");
        effectsPlusButton.clicked += EffectsPlusButton;
        effectsLabel = document.rootVisualElement.Q<Label>("EffectsLabel");

        SetMusicLabel(musicValue);
        SetEffectsLabel(effectsValue);
    }   

    void MusicMinButton()
    {
        if(musicValue <= 0.02)
        {
            return;
        }

        SetMusicLabel(musicValue -= 0.1f);
    }

    void MusicPlusButton()
    {
        if(musicValue >= 0.98)
        {
            return;
        }

        SetMusicLabel(musicValue += 0.1f);
    }

    void SetMusicLabel(float value)
    {
        mainMixer.SetFloat("Music", Mathf.Log(value) * 20f);
        musicLabel.text = (System.Math.Round(value, 1) * 10).ToString();
    }

    void EffectsMinButton()
    {
        if (effectsValue <= 0.02)
        {
            return;
        }

        SetEffectsLabel(effectsValue -= 0.1f);
    }

    void EffectsPlusButton()
    {
        if (effectsValue >= 0.98)
        {
            return;
        }

        SetEffectsLabel(effectsValue += 0.1f);
    }

    void SetEffectsLabel(float value)
    {
        mainMixer.SetFloat("Effects", Mathf.Log(value) * 20f);
        effectsLabel.text = (System.Math.Round(value, 1) * 10).ToString();
    }
}
