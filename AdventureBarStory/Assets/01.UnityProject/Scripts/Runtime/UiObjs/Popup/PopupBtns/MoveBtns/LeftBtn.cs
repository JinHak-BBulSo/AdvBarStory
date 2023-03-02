using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    PlayerController playerController = default;
    void Start()
    {
        playerController = PlayerManager.instance.player.GetComponent<PlayerController>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.isLeft = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.isLeft = false;
    }
}
