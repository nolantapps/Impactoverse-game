using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionData : MonoBehaviour
{
    public string _ArtDataTag = "ArtData",FrontDoor = "FrontDoor",WelcomeSpeach="WelcomeSpeach",_CloverLeaf="CloverLeaf",Meditation="Meditation",ExhbDoor="ExhibitionDoor",_TateDrawEasal="Easal";

    public ArtData _ArtData;

    public UIManagerMBM _UIManager;

    public GameManagerMBM _GameManager;

    public GameObject _GingkoHealing,_TokenUpdateParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_ArtDataTag))
        {
            _ArtData = other.GetComponent<ArtData>();
            _UIManager.SetArtDetail(_ArtData);
        }
        if (other.CompareTag(FrontDoor))
        {
            //_GameManager.OpenDoor();

            _UIManager.SelectPuzzlePanel.SetActive(true);
        }
        if (other.CompareTag(WelcomeSpeach))
        {
            other.gameObject.SetActive(false);
            _UIManager._WelcomeSpeach.SetActive(true);
        }
        if (other.CompareTag(_CloverLeaf))
        {
            TokenSystem.Instance.UpdateToken(2, TokenTypes.Nature_Lover);
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag(Meditation))
        {
            _UIManager._MeditationPanel.SetActive(true);
            _UIManager.GamePlayBttns(false);
        }
        if (other.CompareTag(ExhbDoor))
        {
            _GameManager.OpenExhbDoor();
        }
        if (other.CompareTag(_TateDrawEasal))
        {
            _UIManager.TateDrawPanel.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name, collision.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_ArtDataTag))
        {
            _UIManager.ArtExit();
        }
        if (other.CompareTag(FrontDoor))
        {
            _UIManager.SelectPuzzlePanel.SetActive(false);
        }
        if (other.CompareTag(Meditation))
        {
            _UIManager._MeditationPanel.SetActive(false);
            _UIManager.GamePlayBttns(true);
        }
    }
}
