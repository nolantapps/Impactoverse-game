using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodTracking : MonoBehaviour
{
    public Text _SpaceExperienceTitle;

    public string[] Spaces;

    public int _SpaceIndex;

    public GameObject _MoodPanel;

    public float TokenAmount;

    //private void OnEnable()
    //{
    //    SetMoodPanel(_SpaceIndex);
    //}
    public void SetMoodPanel(int x)
    {
        _SpaceExperienceTitle.text = Spaces[x];
        _MoodPanel.SetActive(true);
    }
    public void MoodTapped(MoodBttn _Bttn)
    {
        Debug.Log(_Bttn.row + " , " + _Bttn.column);
        _MoodPanel.SetActive(false);
        TokenSystem.Instance.UpdateToken(TokenAmount,TokenTypes.Philanthropist);
    }
}
