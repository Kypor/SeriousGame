using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [Header("Musica")]
    [SerializeField] private TextMeshProUGUI sliderTextMusic;
    [SerializeField] Slider sliderVolume;
    [Header("SFX")]
    [SerializeField] private TextMeshProUGUI sliderTextSFX;    
    [SerializeField] Slider sliderSFX;

    public void Start()
    {

        if (MouseSetting.Instance != null)
        {
            sliderVolume.value = MouseSetting.Instance.musicVolume;
            sliderSFX.value = MouseSetting.Instance.sfxVolume;
        }
            

    }
    public void SetVolumeMusic(float sliderValue)
    {
        audioMixer.SetFloat("Music", MathF.Log10(sliderValue) * 50);
        sliderTextMusic.SetText((sliderValue * 100f).ToString("F0"));

        if (MouseSetting.Instance != null)
            MouseSetting.Instance.musicVolume = sliderVolume.value;
    }

    public void SetVolumeSFX(float sliderValue)
    {
        audioMixer.SetFloat("SFX", MathF.Log10(sliderValue) * 50);
        sliderTextSFX.SetText((sliderValue * 100f).ToString("F0"));

        if (MouseSetting.Instance != null)
            MouseSetting.Instance.sfxVolume = sliderSFX.value;
    }
}
