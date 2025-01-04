using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gingko : MonoBehaviour
{
    public Outline _outline;
    public GameObject _GinkoPanel;
    public BoxCollider _BoxColliderTrigger;
    public BoxCollider _BoxCollderPower;


    public GameObject _TapBttn;

    public Image _Filler;

    public float _timer = 0;

    public float _TotalTime;

    public bool IsLearnedGingko;

    public bool IsPointerDown, IsPointerUp;

    public SpawnManager _SpawnManager;



    private void OnTriggerEnter(Collider other)
    {
        if (IsLearnedGingko)
        {
            if (other.CompareTag("Player"))
            {
                _TapBttn.SetActive(true);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (IsLearnedGingko)
        {
            if (other.CompareTag("Player"))
            {
                _TapBttn.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if (IsPointerDown)
        {
            OnPointerStayed();
        }
        if (IsPointerUp)
        {
            OnPointerUp();
        }

    }

    public void PointerDown()
    {
        IsPointerDown = true;
        IsPointerUp = false;
        _SpawnManager.PlayGingkoAnim();
        SoundSystemMBM.Instance.PlayPowerGainGingko();
    }
    public void PointerUp()
    {
        IsPointerDown = false;
        IsPointerUp = true;
        SoundSystemMBM.Instance.StopMusicEffects();
        _SpawnManager.PlayLoco();
    }

    public void OnPointerStayed()
    {
        _timer += Time.deltaTime;
        _Filler.fillAmount = (_timer / 10);

        if (_timer >= _TotalTime)
        {
            _TapBttn.SetActive(false);
            //_BoxColliderTrigger.enabled = false;
            PointerUp();
            OnPointerUp();
            PowerGainComplete();
        }
    }

    public void OnPointerUp()
    {
        _timer = 0;
        _Filler.fillAmount = (_timer / 10);
    }

    private void OnMouseDown()
    {
        if (!IsLearnedGingko)
        {
            _GinkoPanel.SetActive(true);
            SoundSystemMBM.Instance.PlayBttnTapped();
            _BoxColliderTrigger.enabled = false;
            _outline.enabled = false;
            _BoxCollderPower.enabled = true;
            IsLearnedGingko = true;
        }
    }

    public void PowerGainComplete()
    {
        TokenSystem.Instance.UpdateToken(5, TokenTypes.Nature_Lover);
        //_SpawnManager._UIManager.ShowMoodPanel = true;
    }
}
