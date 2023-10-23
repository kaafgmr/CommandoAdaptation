using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string AudioName;

    public void SetVolume(float value)
    {
        audioMixer.SetFloat(AudioName, Mathf.Log10(value) * 20);
    }
}