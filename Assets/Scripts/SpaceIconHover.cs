using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpaceIconHover : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{

    public GameObject _Details;

    public Animator _CircleAnim;

    public void OnPointerExit(PointerEventData eventData)
    {
        CancelInvoke(nameof(DisableDetail));
        Debug.LogError("Pointer Enter");
        _Details.SetActive(false);
        _CircleAnim.enabled = true;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Invoke(nameof(DisableDetail), 3f);
    }
    void DisableDetail()
    {
        _Details.SetActive(true);
        _CircleAnim.enabled = false;
    }


}
