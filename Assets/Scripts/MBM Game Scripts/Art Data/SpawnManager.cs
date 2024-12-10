using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
public class SpawnManager : MonoBehaviour
{


    public Transform[] _Player;

    public vThirdPersonInput[] _PlayerInput;
    public vThirdPersonController _PlayerController;

    public Transform SpawnPos, GinkoTeleportPos;

    public Animator[] _Animator;

    public PlayerCollisionData[] _PlayerData;

    public UIManagerMBM _UIManager;


    public void TeleportPlayerToGinko()
    {
        int x = 0;
        foreach (Transform t in _Player)
        {
            if (_PlayerInput[x].gameObject.activeInHierarchy)
            {
                _PlayerInput[x].enabled = false;
                t.SetPositionAndRotation(GinkoTeleportPos.position, GinkoTeleportPos.rotation);
                _PlayerInput[x].enabled = true;
            }
        }
    }

    public void PlayGingkoAnim()
    {
        int x = 0;
        foreach (Animator a in _Animator)
        {
            if (a.gameObject.activeInHierarchy)
            {
                a.Play("TouchGingko");
                _PlayerData[x]._GingkoHealing.SetActive(true);
            }
            x++;
        }
    }
    public void PlayLoco()
    {
        int x = 0;
        foreach (Animator a in _Animator)
        {
            if (a.gameObject.activeInHierarchy)
            {
                a.SetTrigger("EnterLoco");
                _PlayerData[x]._GingkoHealing.SetActive(false);
            }
            x++;
        }
    }
    public PlayerCollisionData CheckPlayerData()
    {
        foreach (PlayerCollisionData p in _PlayerData)
        {
            if (p.gameObject.activeInHierarchy)
            {
                return p;
            }
        }
        return null;
    }

    public void InfoTapped(bool state)
    {
        foreach (vThirdPersonInput p in _PlayerInput)
        {
            if (p.gameObject.activeInHierarchy)
            {
                p.enabled = state;
            }
        }
    }
}
