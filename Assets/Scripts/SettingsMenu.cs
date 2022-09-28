using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer AllMixer;
    public AudioMixerGroup Game;
    public AudioMixerGroup Music;
    public void SetVolume(float volume)
    {
        AllMixer.SetFloat("volume", volume);
    }
    public void SetMusicVolume(float musicvolume)
    {
        AllMixer.SetFloat("musicvolume", musicvolume);
    }
    public void SetGameVolume(float gamevolume)
    {
        AllMixer.SetFloat("gamevolume", gamevolume);
    }
}