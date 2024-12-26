using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
public class SpawnManager : MonoBehaviour
{

    public static SpawnManager instance;
    public Transform[] _Player;

    public vThirdPersonInput[] _PlayerInput;
    public vThirdPersonController _PlayerController;

    public Transform SpawnPos, GinkoTeleportPos;

    public Animator[] _Animator;

    public PlayerCollisionData[] _PlayerData;

    public UIManagerMBM _UIManager;

    public CharacterSelector _CurrentCharacter;
    public GameManagerMBM gameManager;
    private void Awake()
    {
        instance = this;
    }
    public void TeleportPlayerToGinko()
    {
        _CurrentCharacter.currentCharacter.controller.enabled = false;
        _CurrentCharacter.currentCharacter.controller.transform.SetPositionAndRotation(GinkoTeleportPos.position, GinkoTeleportPos.rotation);
        gameManager.ToggleCameraOn_Off(false);
        _CurrentCharacter.currentCharacter.controller.enabled = true;
        //int x = 0;
        //foreach (Transform t in _Player)
        //{
        //    if (_PlayerInput[x].gameObject.activeInHierarchy)
        //    {
        //        _PlayerInput[x].enabled = false;
        //        t.SetPositionAndRotation(GinkoTeleportPos.position, GinkoTeleportPos.rotation);
        //        _PlayerInput[x].enabled = true;
        //    }
        //}
    }

    public void PlayGingkoAnim()
    {
               _CurrentCharacter.currentCharacter.controller.gameObject.GetComponent<Animator>().Play("TouchGingko");
                _CurrentCharacter.currentCharacter.controller.gameObject.GetComponent<PlayerCollisionData>()._GingkoHealing.SetActive(true);
         
    }
    public void PlayLoco()
    {
       
                _CurrentCharacter.currentCharacter.controller.gameObject.GetComponent<Animator>().SetTrigger("EnterLoco");
                _CurrentCharacter.currentCharacter.controller.gameObject.GetComponent<PlayerCollisionData>()._GingkoHealing.SetActive(false);
         
    }
    public PlayerCollisionData CheckPlayerData()
    {
        return _CurrentCharacter.currentCharacter.controller.gameObject.GetComponent<PlayerCollisionData>();
        
    }

    public void InfoTapped(bool state)
    {
        
                _CurrentCharacter.currentCharacter.controller.gameObject.GetComponent<vThirdPersonInput>().enabled = state;
            
        
    }
}
