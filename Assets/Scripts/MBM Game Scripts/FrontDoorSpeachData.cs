using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrontDoorSpeachData : MonoBehaviour
{
    public Text _SpeachText;

    public SpeachData[] _SpeachData;

    public AudioClip[] _SpeachAudio;

    public AudioSource _AudioSource;

    private void OnEnable()
    {
        _SpeachText.text = _SpeachData[0].WelcomeSpeach;
        _AudioSource.clip = _SpeachAudio[0];
        _AudioSource.Play();
    }
}
[System.Serializable]
public class SpeachData
{
    public AgeGroup _AgeGroup;
    public string WelcomeSpeach;
}