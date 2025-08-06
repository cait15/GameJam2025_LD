using UnityEngine.Audio;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; // Reference to the AudioMixer
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume); // Set the volume in the AudioMixer
    }
}
