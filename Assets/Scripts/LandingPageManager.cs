using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPageManager : MonoBehaviour
{
    public Transform _Camera;

    public Transform[] CamPos;

    public int Index;


    public void StartLerp(int index)
    {
        StartCoroutine(LerpCam(CamPos[index]));
    }

    IEnumerator LerpCam(Transform _Pos)
    {

        float elapsed = 0;
        float time = 2f;

        Vector3 _CurrentPos = _Camera.position;
        Quaternion _CurrentRot = _Camera.rotation;

        while (elapsed < time)
        {
            _Camera.SetPositionAndRotation(Vector3.Lerp(_CurrentPos, _Pos.position, elapsed / time), Quaternion.Lerp(_CurrentRot, _Pos.rotation, elapsed / time));
            elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _Camera.position = _Pos.position;
        _Camera.rotation = _Pos.rotation;
    }
}
