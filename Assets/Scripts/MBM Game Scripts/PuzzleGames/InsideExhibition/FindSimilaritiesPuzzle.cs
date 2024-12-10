using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindSimilaritiesPuzzle : MonoBehaviour
{
    public SimilaritiesData[] _PictureDataUnder18, _PictureDatabove18;

    public Image _ImageFirst, _ImageSecond;

    public Sprite _ImageOne, _ImageTwo;

    public SimilaritiesData _Current;

    public int index = 0;

    public Text _CorrectAnswer, WrongAnswer, _TimerText, _CompleteText,PuzzleText;

    public int CorrectCount = 0, WrongCount = 0;

    public float _TotalTime;

    public float _CurrentTimer;

    public bool isStarted;

    public GameObject _Complete,StartPanel,GamePlayPanel;

    public float TotalTokens;
    private void OnEnable()
    {
        StartPanel.SetActive(true);
        _Complete.SetActive(false);
        GamePlayPanel.SetActive(false);

    }
    public void StartGame()
    {
        index = 0;
        CorrectCount = 0;
        WrongCount = 0;
        _CurrentTimer = _TotalTime;
        isStarted = true;
        _ImageFirst.sprite = _ImageOne;
        _ImageSecond.sprite = _ImageTwo;
        _CorrectAnswer.text = CorrectCount.ToString();
        WrongAnswer.text = WrongCount.ToString();
        SetPanel(index);
    }
    public void SetPanel(int x)
    {
        _Current = _PictureDataUnder18[x];
        PuzzleText.text = _PictureDataUnder18[x].PuzzleText;
    }

    public void CheckAnswer(bool isTrueSelected)
    {
        if (isTrueSelected == _PictureDataUnder18[index].IsSimilar)
        {
            CorrectCount += 1;
            _CorrectAnswer.text = CorrectCount.ToString();
        }
        else
        {
            WrongCount += 1;
            WrongAnswer.text = WrongCount.ToString();
        }
        index++;
        if (index >= _PictureDataUnder18.Length)
        {
            Complete();
        }
        else
        {
            SetPanel(index);
        }
    }
    private void Update()
    {
        if (isStarted)
        {
            CheckTime();

        }
    }
    void CheckTime()
    {
        _CurrentTimer -= Time.deltaTime;
        DisplayTime(_CurrentTimer, _TimerText);
        if (_CurrentTimer <= 0)
        {
            Complete();
        }
    }
    void DisplayTime(float timeToDisplay, Text timeText)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void Complete()
    {
        //_Complete.SetActive(true);
        _CompleteText.text = "Total Correct : " + _CorrectAnswer + "  Total Wrong : " + WrongAnswer;
        isStarted = false;
        gameObject.SetActive(false);
        TokenSystem.Instance.UpdateToken(TotalTokens,TokenTypes.Competitor);

    }
}

[System.Serializable]
public class SimilaritiesData
{
    public string PuzzleText;
    public bool IsSimilar;
}