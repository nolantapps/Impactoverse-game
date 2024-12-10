using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WhyBotherPuzzle : MonoBehaviour
{
    public TMP_InputField _InputField;

    public Image[] _Buttons;

    public GameObject _SubmitBttn;

    public string _OtherReason;

    public int ReasonIndex;

    public GameManagerMBM _GameMAnager;
    public void Tapped(Image _Image)
    {
        ResetColors();
        _Image.color = Color.green;
        _SubmitBttn.SetActive(true);
    }
    public void ResetColors()
    {
        _SubmitBttn.SetActive(false);
        foreach (Image i in _Buttons)
        {
            i.color = Color.white;
        }
    }
    public void SetIndex(int index)
    {
        ReasonIndex = index;
    }
    public void OnFieldInput()
    {
        _OtherReason = _InputField.text;
        if (_InputField.text.Length > 3)
        {
            _InputField.image.color = Color.green;
            _SubmitBttn.SetActive(true);
        }
        else
        {
            _InputField.image.color = Color.white;
            _SubmitBttn.SetActive(false);
        }
    }

    public void SubmittedTapped()
    {
        gameObject.SetActive(false);
        _GameMAnager.OpenDoor();

    }
   
}
