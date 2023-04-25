using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle muteToggle;
    private bool muted = false;
    private void Start()
    {
        // if no previously saved volume amt
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            // set to 100%
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            // load prev amount
            Load();
        }
        // if no prev mute setting saved then set false
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    // function to control toggle mute
    public void onToggle()
    {
        // if we click it and muted is false, then mute and pause audio
        if (muted == false)
        {
            Debug.Log("Audio is muted");
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            Debug.Log("Audio is unmuted");
            muted = false;
            AudioListener.pause = false;
        }
        // save preference
        Save();
    }
}
