using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class SpotTheKey : MonoBehaviour
{
    public GameObject _Key;

    public bool GameStarted;

    public GameObject PickKey, OpenDoor;

    public GameManagerMBM _GameManager;

    public int TotalTokens;

    public bool KeyPicked;


    public void GameStartedTapped()
    {
        GameStarted = true;
        _Key.SetActive(true);
    }

    public void PickKeyTapped()
    {
        _Key.SetActive(false);
        KeyPicked = true;
    }

    public void OpenDoorTapped()
    {
        _GameManager.OpenDoor();
        TokenSystem.Instance.UpdateToken(TotalTokens, TokenTypes.Competitor);
        GameStarted = false;

    }
}
