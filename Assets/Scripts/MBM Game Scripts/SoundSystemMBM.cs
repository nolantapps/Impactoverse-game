using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystemMBM : MonoBehaviour
{
    public static SoundSystemMBM Instance;

    public AudioSource _MainMusicSource, _EffectsMusicSource;

    public AudioClip _PopUpEffect, BttnTapEffect, BGMusic, GainTOkenEffect, PowerGainMeditation, PowerGainGingko;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        PlayBGMusic();
    }

    public void PlayBGMusic()
    {
       // _MainMusicSource.clip = BGMusic;
       // _MainMusicSource.Play();
    }

    public void PlayPopUpEffect()
    {
       // _EffectsMusicSource.PlayOneShot(_PopUpEffect);
    }
    public void PlayBttnTapped()
    {
       // _EffectsMusicSource.PlayOneShot(BttnTapEffect);

    }
    public void PlayPowerGainMeditation()
    {
       // _EffectsMusicSource.PlayOneShot(PowerGainMeditation);
    }
    public void PlayPowerGainGingko()
    {
        //_EffectsMusicSource.PlayOneShot(PowerGainGingko);
    }
    public void PlayTokenGained()
    {
        //_EffectsMusicSource.PlayOneShot(GainTOkenEffect);
    }

    public void StopMusicEffects()
    {
       // _EffectsMusicSource.Stop();
    }
}
