using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    public GameObject _PondPanel;

    public GameObject _FirstPAnel, _SecondPanel;

    public Outline _Outline;

    private void OnMouseDown()
    {
        _Outline.enabled = false;
        _PondPanel.SetActive(true);
        _FirstPAnel.SetActive(true);
        _SecondPanel.SetActive(false);
    }
}
