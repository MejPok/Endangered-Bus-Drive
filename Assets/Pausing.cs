using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Pausing : MonoBehaviour
{
    public GameObject UiPanel;

    public Slider musicVolumeSlider;
    public float musicVolume;
    public Slider effectsVolumeSlider;
    public float effectsVolume;

    public bool paused;


    void Start()
    {
        if (!PlayerPrefs.HasKey("music") || !PlayerPrefs.HasKey("effects"))
        {
            PlayerPrefs.SetInt("music", 30);
            PlayerPrefs.SetInt("effects", 100);
        }



        musicVolumeSlider.maxValue = 100;
        effectsVolumeSlider.maxValue = 100;
        musicVolumeSlider.value = PlayerPrefs.GetInt("music");
        effectsVolumeSlider.value = PlayerPrefs.GetInt("effects");


        paused = false;
        
        musicVolume = musicVolumeSlider.value;
        effectsVolume = effectsVolumeSlider.value;

        PlayerPrefs.SetInt("music", (int)musicVolume);
        PlayerPrefs.SetInt("effects", (int)effectsVolume);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            UiPanel.SetActive(paused);
        }

        if (paused)
        {
            musicVolume = musicVolumeSlider.value;
            effectsVolume = effectsVolumeSlider.value;

            PlayerPrefs.SetInt("music", (int)musicVolume);
            PlayerPrefs.SetInt("effects", (int)effectsVolume);
        }
    }
}
