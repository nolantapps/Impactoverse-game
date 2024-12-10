using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrackTheCodePuzzle : MonoBehaviour
{
    public TMP_InputField _InputField;

    public Image _InputFieldBg;

    public string ValueSubmited;

    public GameManagerMBM _GameMAnager;

    public float TotalTokens;
    public void SetValue()
    {
        _InputFieldBg.color = Color.white;
        ValueSubmited = _InputField.text;
    }

    public void SubmitedTapped()
    {
        if (ValueSubmited == "145")
        {
            _InputFieldBg.color = Color.green;
            Invoke(nameof(Submited), 2f);

        }
        else
        {
            _InputFieldBg.color = Color.red;
        }
    }

    public void Submited()
    {
        _GameMAnager.OpenDoor();
        gameObject.SetActive(false);
        TokenSystem.Instance.UpdateToken(TotalTokens,TokenTypes.Competitor);
    }




}
