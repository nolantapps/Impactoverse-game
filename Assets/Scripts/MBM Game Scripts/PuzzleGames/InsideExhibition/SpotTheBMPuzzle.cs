using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotTheBMPuzzle : MonoBehaviour
{
    public BMPuzzle[] BMPuzzleData;

    public GameObject _StartPanel, GamePanel;

    public BMPuzzle _Current;

    public int index = 0;

    public Text _CorrectAnswer, WrongAnswer, _TimerText, _CompleteText;

    public int CorrectCount = 0, WrongCount = 0;

    public Image _ImageMain;

    public float _TotalTime;

    public float _CurrentTimer;

    public bool isStarted;

    public GameObject _Complete;

    public float TotalTokens;

    private void OnEnable()
    {
        _StartPanel.SetActive(true);
        _Complete.SetActive(false);
        GamePanel.SetActive(false);
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

    public void StartGame()
    {
        _StartPanel.SetActive(false);
        GamePanel.SetActive(true);
        index = 0;
        CorrectCount = 0;
        WrongCount = 0;
        _CurrentTimer = _TotalTime;
        isStarted = true;
        SetPanel(index);
    }

    void SetPanel(int x)
    {
        _Current = BMPuzzleData[x];
        _ImageMain.sprite = _Current.Image;
    }

    public void CheckAnswer(bool IsTrueSelected)
    {
        if (_Current.IsBMWork == IsTrueSelected)
        {
            CorrectCount++;
            _CorrectAnswer.text = CorrectCount.ToString();
        }
        else
        {
            WrongCount++;
            WrongAnswer.text = WrongCount.ToString();
        }
        index++;
        if (index >= BMPuzzleData.Length)
        {
            Complete();
        }
        else
        {
            SetPanel(index);
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
        gameObject.SetActive(false);
        //_CompleteText.text = "Total Correct : " + _CorrectAnswer + "  Total Wrong : " + WrongAnswer;
        isStarted = false;
        TokenSystem.Instance.UpdateToken(TotalTokens,TokenTypes.Creator);
    }
}

[System.Serializable]
public class BMPuzzle
{
    public Sprite Image;
    public bool IsBMWork;
}