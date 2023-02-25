using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField]private AudioClip introBGM;
    [SerializeField]private AudioClip environmentBGM;
    [SerializeField]private AudioClip ambienceBGM;
    [SerializeField]private AudioClip finalBGM;
    [SerializeField] public AudioClip sfx_defaultopen;
    [SerializeField] public AudioClip sfx_defaultclose;


    [SerializeField] private AudioSource _audioSource;
    [SerializeField] public GameObject audioSourcePrefab; //used for doors that doesn't have it's own audiosource yet.
    [Range(0, 1)] public float volume;
    public float durationFade = 0.5f;
    public List<SoundEffects> sfxs = new List<SoundEffects>();
    public List<SoundEffects> animals = new List<SoundEffects>();
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _audioSource.loop = true;
        _audioSource.clip = introBGM;
        _audioSource.volume = volume;
        // _audioSource.Play();
    }
    public void PlayIntro()
    {
        StartCoroutine(delayBGMFade(introBGM));
    }

    IEnumerator delayBGMFade(AudioClip clip)
    {

        yield return new WaitForSeconds(durationFade);
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void PlayEnvironment()
    {
        StartCoroutine(delayBGMFade(environmentBGM));

    }


    public void PlayAmbience()
    {
        StartCoroutine(delayBGMFadeBattle(ambienceBGM));

    }

    public void PlayFinalBattle()
    {
        StartCoroutine(delayBGMFadeBattle(finalBGM));

    }
    
    IEnumerator delayBGMFadeBattle(AudioClip clip)
    {
        float duration = 0.5f;
        // _audioSource.DOFade(0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        _audioSource.clip = clip;
        _audioSource.Play();
        // _audioSource.DOFade(volume, duration);
    }

    public void PlaySFX(SFX sfx)
    {   
        foreach (var sf in sfxs)
        {
            if (sf.sfxEnum == sfx)
            {
                _audioSource.PlayOneShot(sf.clip);
                return;
            }
        }
    }

    public void SetVolume(float value)
    {
        volume = value;
        _audioSource.volume = volume;
    }
    
    public void PlayButton()
    {
        PlaySFX(SFX.BUTTON);
    }

    public void PlatFootstep()
    {
        int random = UnityEngine.Random.Range(0, sfxs.Count);
        _audioSource.PlayOneShot(sfxs[random].clip);
    }
    public void PlatAnimalSounds()
    {
        int random = UnityEngine.Random.Range(0, animals.Count);
        _audioSource.PlayOneShot(animals[random].clip);
    }
}

    [Serializable]
    public class SoundEffects
    {
        public SFX sfxEnum;
        public AudioClip clip;
    }

    public enum SFX
    {
        PAPER,
        BUTTON,
        HIRE,
        REJECT,
        SELL,
        BELL
    }
