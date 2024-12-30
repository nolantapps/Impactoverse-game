using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystemMBM : MonoBehaviour
{
    public static SoundSystemMBM Instance;

    public AudioClip[] GamePlayMusciList;

    public AudioSource _MainMusicSource, _EffectsMusicSource;

    public AudioClip _PopUpEffect, BttnTapEffect, BGMusic, GainTokenEffect, PowerGainMeditation, PowerGainGingko;

    public int index=0;

    private void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        index = -1;
        //PlayBGMusic();
    }

    private void Update()
    {
        if (!_MainMusicSource.isPlaying) //&& _MainMusicSource.time > 0)
        {
            OnMusicEnd();
        }
    }

    public void PlayBGMusic()
    {
       // _MainMusicSource.clip = BGMusic;
       // _MainMusicSource.Play();
    }

    public void PlayPopUpEffect()
    {
        _EffectsMusicSource.PlayOneShot(_PopUpEffect);
    }
    public void PlayBttnTapped()
    {
        _EffectsMusicSource.PlayOneShot(BttnTapEffect);
    }
    public void PlayPowerGainMeditation()
    {
        _EffectsMusicSource.PlayOneShot(PowerGainMeditation);
    }
    public void PlayPowerGainGingko()
    {
        _EffectsMusicSource.PlayOneShot(PowerGainGingko);
    }
    public void PlayTokenGained()
    {
        _EffectsMusicSource.PlayOneShot(GainTokenEffect);
    }

    public void StopMusicEffects()
    {
        _EffectsMusicSource.Stop();
    }

    public void OnMusicEnd()
    {
        Debug.Log("Music Changed");
        _MainMusicSource.Stop();
        index++;
        if (index >= GamePlayMusciList.Length)
        {
            index = 0;
        }
        _MainMusicSource.clip = GamePlayMusciList[index];
        _MainMusicSource.Play();
    }
}
