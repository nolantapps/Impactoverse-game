using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyISInTheRose : MonoBehaviour
{
    public Button PuzzleButton;

    public Image _ButtonImage;

    public int CorrectCount = 0, FalseCount = 0;

    public int TotalCorrect = 6;

    public GameObject _SubmitButton;

    public GameManagerMBM _GameMAnager;

    public float TotalTokens;

    public void CheckBttn(bool PuzzleState)
    {
        if (PuzzleState)
        {
            if (PuzzleButton != null && _ButtonImage != null)
            {
                PuzzleButton.interactable = false;
                _ButtonImage.color = Color.green;
                CorrectCount += 1;
            }
        }
        else
        {
            if (_ButtonImage.color == Color.red)
            {
                _ButtonImage.color = Color.white;
                FalseCount -= 1;
            }
            else
            {
                _ButtonImage.color = Color.red;
                FalseCount += 1;
            }
        }
        CheckIfSolved();
    }
    public void SetBttnDetail(Image _image)
    {
        _ButtonImage = _image;
        PuzzleButton = _image.GetComponent<Button>();
    }

    void CheckIfSolved()
    {
        if (CorrectCount == TotalCorrect && FalseCount<=0)
        {
            _SubmitButton.SetActive(true);
        }
        else
        {
            _SubmitButton.SetActive(false);
        }
    }

    public void Submited()
    {
        _GameMAnager.OpenDoor();
        gameObject.SetActive(false);
        TokenSystem.Instance.UpdateToken(TotalTokens,TokenTypes.Competitor);
    }
}
