using Michsky.UI.Shift;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManagerMBM : MonoBehaviour
{
    public Image _ArtImage;

    public Text _ArtNameText,_TokenGainedText;

    public Text[] _ArtDetailText;

    public GameObject _InfoButton, _ChangeCamBttn, _ZoomInOut, _RakaHelp, TokenPanel,CompletePanel,TateDrawPanel;

    public GameObject _InfoPanel, _MeditationPanel;

    public GameObject SelectPuzzlePanel;

    public ArtData _CurrentArt;

    public GameObject _ChangeArtBttns, _WelcomeSpeach, FlashObject;

    int index = -1;

    public bool ShowMoodPanel;

    public MoodTracking _MoodManager;
    public static UIManagerMBM Instance;

    public SpawnManager _SpawnManager;

    public CursorDetection _CursorDetection;
    public bool IsTeleported;
    public ArtData _WelcomeRaka;

    private void Awake()
    {
        Instance = this;
    }
    public void SetArtDetail(ArtData _Data)
    {
        _CurrentArt = _Data;
        SetArtPanel(_Data);
        //_InfoButton.SetActive(true);
        //_ChangeCamBttn.SetActive(true);
    }
    public void ArtExit()
    {
        _CurrentArt = null;
        _InfoButton.SetActive(false);
        _InfoPanel.SetActive(false);
        //_ChangeCamBttn.SetActive(false);
    }

    public void InfoTapped()
    {
        if (_CurrentArt.NextArt.Length >= 1)
        {
            Debug.Log(_CurrentArt.NextArt[0]);
            _ChangeArtBttns.SetActive(true);
        }
        else
        {
            _ChangeArtBttns.SetActive(false);
        }
        if (_CurrentArt.GetComponent<Outline>())
        {
            _CurrentArt.GetComponent<Outline>().enabled = false;
        }

        _InfoPanel.SetActive(true);
        _InfoButton.SetActive(false);


    }
    public void ClosePanel()
    {
        _InfoPanel.SetActive(false);
        _InfoButton.SetActive(true);

    }
    public void SetArtPanel(ArtData _Data)
    {
        string[] _Strings = _Data._ArtData._ArtDetail[0]._ArtDetail;
        Sprite _Image = _Data._ArtData._ArtDetail[0]._Images;
        foreach (Text t in _ArtDetailText)
        {
            t.gameObject.SetActive(false);
        }

        for (int i = 0; i < _Strings.Length; i++)
        {
            _ArtDetailText[i].text = _Strings[i];
            _ArtDetailText[i].gameObject.SetActive(true);
        }

        _ArtImage.sprite = _Image;
        _ArtNameText.text = _Data._ArtData._ArtName;
    }
    void SetPanel(string[] _text, Sprite png, string artname)
    {
        string[] _Strings = _text;
        Sprite _Image = png;
        foreach (Text t in _ArtDetailText)
        {
            t.gameObject.SetActive(false);
        }

        for (int i = 0; i < _Strings.Length; i++)
        {
            _ArtDetailText[i].text = _Strings[i];
            _ArtDetailText[i].gameObject.SetActive(true);
        }

        _ArtImage.sprite = _Image;
        _ArtNameText.text = artname;
    }

    public void ChangeArtTapped(int x)
    {
        index += x;

        if (index < -1)
        {
            index = -1;
        }
        if (index > _CurrentArt.NextArt.Length - 1)
        {
            index = _CurrentArt.NextArt.Length - 1;
        }

        if (index == -1)
        {

            SetPanel(_CurrentArt._ArtData._ArtDetail[0]._ArtDetail, _CurrentArt._ArtData._ArtDetail[0]._Images, _CurrentArt._ArtData._ArtName);
        }
        else
        {
            SetPanel(_CurrentArt.NextArt[index]._ArtDetail[0]._ArtDetail, _CurrentArt.NextArt[index]._ArtDetail[0]._Images, _CurrentArt.NextArt[index]._ArtName);
        }
    }

    public void FlashScene()
    {
        FlashObject.SetActive(true);
        Invoke(nameof(disableFlash), 2f);
    }
    void disableFlash()
    {
        FlashObject.SetActive(false);
    }

    public void GamePlayBttns(bool state)
    {
        if (_CurrentArt != null)
        {
            _InfoButton.SetActive(state);
            //_ChangeCamBttn.SetActive(state);
        }
        TokenPanel.SetActive(state);
        if (ShowMoodPanel)
        {
            _MoodManager.SetMoodPanel(2);
            ShowMoodPanel = false;
        }
        if (IsTeleported)
        {
            SetArtDetail(_WelcomeRaka);
            InfoTapped();
            _SpawnManager.InfoTapped(false);
            Debug.LogError("WelcomeRakaOpened");
        }

    }
}
