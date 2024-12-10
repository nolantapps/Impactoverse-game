using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HintManager : MonoBehaviour
{
    public static HintManager Instance;

    public GameObject panel;
  
    public int CurrentHint=0;
    public string[] hints;
    public Text HintText;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateData();
    }
    public void UpdateHint(int hint)
    {
        CurrentHint = CurrentHint + hint;
        if (CurrentHint < 0)
        {
            CurrentHint = 0;
        }
        if (CurrentHint >= hints.Length)
        {
            CurrentHint = hints.Length - 1;
        }
        UpdateData();
    }
    public void UpdateData()
    {
        HintText.text = hints[CurrentHint];
    }
    public void ShowPanel()
    {
        panel.SetActive(true);
    }
    public void HidePanel()
    {
        panel.SetActive(false);
    }
}

