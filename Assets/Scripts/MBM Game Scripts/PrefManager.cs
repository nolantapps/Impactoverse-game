using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefManager : MonoBehaviour
{
    public static string _TotalTokens;

    public static void SetTokens(float x)
    {
        PlayerPrefs.SetFloat(_TotalTokens, PlayerPrefs.GetFloat(_TotalTokens, 0) + x);
    }
    public static float GetTokens()
    {
        return PlayerPrefs.GetFloat(_TotalTokens);
    }

}
