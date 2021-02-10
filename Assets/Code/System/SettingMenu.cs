using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer BGMMixer;
    public AudioMixer SFXMixer;

    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    void start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
    }
    public void SetVolume(float volume)
    {
        BGMMixer.SetFloat("volume", volume);
    }
    public void SetSFX(float volume)
    {
        SFXMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];

        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        
    }
}
