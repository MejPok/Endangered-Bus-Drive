using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public GameObject controlsSpace;
    public AudioSource soundFXobject;

    public AudioClip[] audioClipsSaved;

    public AudioClip wallHit;
    public AudioSource music;

    void Update()
    {
        music.volume = VolumePercentToDecibels(GetComponent<Pausing>().musicVolume);
    }
    void Awake()
    {
        Instance = this;
    }

    public void PlaySoundFX(AudioClip audio, Transform trans, float volume)
    {
        var soundFX = Instantiate(soundFXobject, trans.position, Quaternion.identity);

        soundFX.clip = audio;

        soundFX.volume = VolumePercentToDecibels(volume * (GetComponent<Pausing>().effectsVolume / 100));

        soundFX.Play();

        float clipLength = soundFX.clip.length;

        Destroy(soundFX.gameObject, clipLength);
    }

    public void PlayHitSound()
    {
        PlaySoundFX(wallHit, transform, 50);
    }

    float VolumePercentToDecibels(float percent)
    {
        return Mathf.Clamp01(percent / 100f);
    }   

}
