using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerParameter _parameter;

    public void OnChange(float value) =>
        _audioMixer.SetFloat(_parameter.ToString(), value);
}
