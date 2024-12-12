using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMBM : MonoBehaviour
{
    public BoxCollider _DoorTrigger, ExhbDoorTrigger;

    public Animation _FrontDoor, _ExhibitionDoor;

    public SpawnManager _SpawnManager;

    public MoodTracking _MoodTracking;

    public UIManagerMBM _UIManager;

    public GameObject _ArtCam, _CharacterCam, _ExhbHud, _GinkoHud, _BMWorkHUD,_Walls;

    public Camera _ArtCamera;

    public bool IsArtCam;

    float ArtCamFOV;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (_UIManager._CurrentArt != null)
            {
                ShiftCam(!IsArtCam);
            }

        }
    }

    public void ShiftCam(bool State)
    {
        _ArtCamera.orthographicSize = _UIManager._CurrentArt._CamSize;
        Transform _pos = _UIManager._CurrentArt._CamPos;
        _ArtCam.transform.SetPositionAndRotation(_pos.position, _pos.rotation);
        _UIManager._InfoButton.SetActive(!State);
        _UIManager._ChangeCamBttn.SetActive(!State);
        _UIManager._ZoomInOut.SetActive(State);
        _UIManager._RakaHelp.SetActive(!State);
        _ArtCam.SetActive(State);
        _CharacterCam.SetActive(!State);
        IsArtCam = !IsArtCam;
        ArtCamFOV = _ArtCamera.fieldOfView;
    }

    public void ZoomInOut(float x)
    {
        _ArtCamera.fieldOfView = Mathf.Clamp(_ArtCamera.fieldOfView + x, ArtCamFOV - 10, ArtCamFOV + 10);
    }
    public void OpenDoor()
    {
        _FrontDoor.Play();
        _DoorTrigger.enabled = false;
        HintManager.Instance.UpdateHint(1);
        BMHUDStatus(true);
    }

    public void OpenExhbDoor()
    {
        _ExhibitionDoor.Play();
        ExhbDoorTrigger.enabled = false;
        _ExhbHud.SetActive(false);
    }

    public void TeleportTapped()
    {
        _UIManager.FlashScene();
        Invoke(nameof(TeleportPlayer), 2f);
        ExhbDoorTrigger.enabled = true;
        _GinkoHud.SetActive(true);
        _ExhbHud.SetActive(true);
        _Walls.SetActive(false);
    }
    void TeleportPlayer()
    {
        _SpawnManager.TeleportPlayerToGinko();
        //_MoodTracking.SetMoodPanel(0);
    }

    public void BMHUDStatus(bool state)
    {
        _BMWorkHUD.SetActive(state);
        Debug.LogError("BM HUD Enabled");
    }

    public void VisitTateDraw()
    {
        Application.OpenURL("https://www.tate.org.uk/kids/games-quizzes/tate-draw");
    }
    public void VisitSubmissionForum()
    {
        Application.OpenURL("https://www.tate.org.uk/kids/games-quizzes/tate-draw");
    }

}
