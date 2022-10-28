using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider slider;

    public void SetMainVolume(float volume)
    {
        mainMixer.SetFloat("Master Volume", (slider.value - 75));
    }
}
