using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    [SerializeField] private string musicName;
    void Start()
    {
        AudioManager.instance.StopAllSounds();
        AudioManager.instance.PlaySound(musicName);
    }
}
