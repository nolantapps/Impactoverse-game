using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MeditationManager : MonoBehaviour
{

    public GameObject _StartPanel, _DescriptionPanel, _CompletePanel, _StartBttn, _Canvas, _Character, _Cam, _Spot, _MainCam;

    public Animator _Animator;
    public Animator[] _TotalAnimators;

    public GameObject[] _Timelines;

    public MeditationData[] _MeditationData;

    public UIManagerMBM _UIManager;

    public int index;

    public Text _Title, _Description;

    public float TotalTokens;

   
    public void Breathing()
    {
        _Animator.SetTrigger("breathing");
        
    }
    public void idleAnimation()
    {
        _Animator.SetTrigger("idle");
       
    }
    public void SitDown()
    {
        StartCoroutine(IdleToSit());
    }
    IEnumerator  IdleToSit()
    {
        bool check = true;
        float value = 0;
        while (check)
        {
            value += 0.1f;
            if (value > 1f)
            {
                check = false;
                value = 1f;
            }
            _Animator.SetLayerWeight(1, value);

            yield return new WaitForSeconds(0.1f);

        }
    }
    
    IEnumerator LerpValue(float to , float from )
    {
        if (to > from)
        {
            to = -to;
        }
        bool check = true;
        while (check)
        {
            to += 0.1f;
            
            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator Start()
    {
        index = 0;
        yield return new WaitForSeconds(1f);
        
        foreach (Animator a in _TotalAnimators)
        {
            if (a.gameObject.activeInHierarchy)
            {
                _Animator = a;
            }
        }
    }
    public void StartMeditation()
    {
        SetMeditation(index);
        _StartPanel.SetActive(false);
        _UIManager.FlashScene();
        _UIManager.TokenPanel.SetActive(false);
        Invoke(nameof(SetPanel),2f);
    }

    void SetPanel()
    {
        _Character.SetActive(true);
        _MainCam.SetActive(false);
        _Cam.SetActive(true);
        _Spot.SetActive(false);
        _DescriptionPanel.SetActive(true);
    }
    public void PlayMeditation()
    {
        _DescriptionPanel.SetActive(false);
        _StartBttn.SetActive(true);
    }
    public void EnableTimeline()
    {
        _StartBttn.SetActive(false);
        _Timelines[index].SetActive(true);
    }
    public void SetMeditation(int x)
    {
        _Title.text = _MeditationData[x]._Title;
        _Description.text = _MeditationData[x]._Description;
    }

    public void PlayAnimation(int x)
    {
        //_Animator.Play(_MeditationData[x]._AnimationID);
    }

    public void SetNext()
    {
        _Timelines[index].SetActive(false);
        index++;
        if (index >= _MeditationData.Length)
        {
            Complete();
        }
        else
        {
            SetMeditation(index);
            SetPanel();
            //PlayMeditation();
        }

    }
    void Complete()
    {
        index = 0;
        _Character.SetActive(false);
        _MainCam.SetActive(true);
        _Cam.SetActive(false);
        _Spot.SetActive(false);
        _StartPanel.SetActive(true);
        _Canvas.SetActive(false);
        gameObject.SetActive(false);
        _UIManager.GamePlayBttns(true);
        TokenSystem.Instance.UpdateToken(TotalTokens,TokenTypes.Nature_Lover);
    }
}
[System.Serializable]
public class MeditationData
{
    public string _Title, _Description,_AnimationID;
}