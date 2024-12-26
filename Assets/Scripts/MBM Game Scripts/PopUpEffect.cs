using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpEffect : MonoBehaviour
{

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        SoundSystemMBM.Instance.PlayPopUpEffect();
    }
}
