using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{

    public Slider volumeSlider;

    private const string VolumeKey = "soundVolume";

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(VolumeKey))
        {
            PlayerPrefs.SetFloat(VolumeKey, 1);
        }
        Load();
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(VolumeKey);
    }

    void Save()
    {
        PlayerPrefs.SetFloat(VolumeKey, volumeSlider.value);
    }
    
    
}

