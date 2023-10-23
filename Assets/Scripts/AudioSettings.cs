using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[Serializable]
public class AudioChanger
{
    public string AudioName;
    public Slider AudioSlider;
}

public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public List<AudioChanger> audioChangerList;

    private void Awake()
    {
        LoadAudioSettings();
    }

    public void LoadAudioSettings()
    {
        foreach(AudioChanger audio in audioChangerList)
        {
            float volume = GetValueOf(audio.AudioName) <= 0f ? 1 : GetValueOf(audio.AudioName);

            if (audio.AudioSlider != null)
            {
                audio.AudioSlider.value = volume;
            }

            SetAudioTo(audio.AudioName, volume);
        }
    }

    public void SetAudioTo(string name, float value)
    {
        PlayerPrefs.SetFloat(name, value);
        audioMixer.SetFloat(name, Mathf.Log10(value) * 20);
    }

    public float GetValueOf(string name)
    {
        return PlayerPrefs.GetFloat(name);
    }

    public void SaveAudioSettings()
    {
        foreach (AudioChanger audio in audioChangerList)
        {
            SetAudioTo(audio.AudioName, audio.AudioSlider.value);
        }

        PlayerPrefs.Save();
    }
}