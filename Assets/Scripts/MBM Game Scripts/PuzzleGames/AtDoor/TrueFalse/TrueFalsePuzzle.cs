using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrueFalsePuzzle : MonoBehaviour
{
    public TrueFalsePuzzleData[] Datas;

    public GameObject _GamePanel, PlayBttnPanel, AnswerButtons,SubmitBttn,CloseBttn;

    public Image _QuestionBg;

    public Text _Question,CompleteText;

    public bool _Answer;

    public int QuestionIndex = 0;

    public int TotalCorrectAnswers = 0;

    public GameObject CompletePanel;

    public GameManagerMBM _GameMAnager;

    public float TotalTokens;
    public void SetQuestion()
    {
        if (QuestionIndex >= Datas[0]._QuestionData.Length)
        {
            CheckAnswers();
        }
        else
        {
            AnswerButtons.SetActive(true);
            _QuestionBg.color = Color.white;
            _Question.text = Datas[0]._QuestionData[QuestionIndex].Question;
            _Answer = Datas[0]._QuestionData[QuestionIndex].QuestionBool;
            QuestionIndex++;
        }
       
    }

    public void PlayTapped()
    {
        PlayBttnPanel.SetActive(false);
        _GamePanel.SetActive(true);
        QuestionIndex = 0;
        TotalCorrectAnswers = 0;
        SetQuestion();
    }

    public void TrueFalseTapped(bool IstrueSelected)
    {
        AnswerButtons.SetActive(false);
        if (IstrueSelected == _Answer)
        {
            _QuestionBg.color = Color.green;
            TotalCorrectAnswers++;
        }
        else
        {
            _QuestionBg.color = Color.red;

        }
        Invoke(nameof(SetQuestion), 3f);
    }
    void CheckAnswers()
    {
        CompletePanel.SetActive(true);
        if (TotalCorrectAnswers >= 4)
        {
            CompleteText.text = "PuzzleComplete";
            SubmitBttn.SetActive(true);
            CloseBttn.SetActive(false);
        }
        else
        {
            CompleteText.text = "Puzzle Failed Retry Again";
            SubmitBttn.SetActive(false);
            CloseBttn.SetActive(true);
        }
    }

    public void Submited()
    {
        _GameMAnager.OpenDoor();
        gameObject.SetActive(false);
        TokenSystem.Instance.UpdateToken(TotalTokens,TokenTypes.Competitor);
    }
}



[System.Serializable]
public class TrueFalsePuzzleData
{
    public AgeGroup _AgeGroup;

    public QuestionData[] _QuestionData;

}
[System.Serializable]
public class QuestionData
{
    public string Question;
    public bool QuestionBool;
}