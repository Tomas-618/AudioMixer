using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerParameter _parameter;

    private float _volume;
    private bool _isMuted;

    public void OnChange(float value)
    {
        _volume = value;

        if (_isMuted)
            return;

        _audioMixer.SetFloat(_parameter.ToString(), value);
    }

    public void ChangeMutingState()
    {
        int minVolume = -80;

        _audioMixer.SetFloat(_parameter.ToString(), _isMuted ? _volume : minVolume);
        _isMuted = !_isMuted;
    }
}
