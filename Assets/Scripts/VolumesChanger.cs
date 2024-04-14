using UnityEngine;
using UnityEngine.Audio;

public class VolumesChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public void OnChange(float value) =>
        _audioMixer.SetFloat(AudioMixerParams.MasterVolume, value);
}
