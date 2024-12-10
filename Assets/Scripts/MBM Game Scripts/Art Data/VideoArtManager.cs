using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoArtManager : MonoBehaviour
{
    public VideoPlayer _VideoPlayer;

    public Transform _CamPos;

    public Camera _ArtCam;

    public GameObject _MainCam;

    public float Size;

    public GameManagerMBM _GameManager;

    public GameObject _Image;


    private void OnEnable()
    {
        _VideoPlayer.loopPointReached += OnVideoEnd;

    }
    private void OnDisable()
    {
        _VideoPlayer.loopPointReached -= OnVideoEnd;

    }

    private void OnVideoEnd(VideoPlayer source)
    {
        ExitVideo();
        _Image.SetActive(true);
    }


    public void StartVideo()
    {
        _ArtCam.transform.SetPositionAndRotation(_CamPos.position, _CamPos.rotation);
        _ArtCam.gameObject.SetActive(true);
        _ArtCam.orthographicSize = Size;
        _MainCam.SetActive(false);
        _VideoPlayer.Play();
        _Image.SetActive(false);
    }

    public void ExitVideo()
    {
        _MainCam.SetActive(true);
        _ArtCam.gameObject.SetActive(false);
        _VideoPlayer.Stop();
        _GameManager._MoodTracking.SetMoodPanel(1);
    }

}
