using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    PlayerController playerController = default;
    void Start()
    {
        playerController = PlayerManager.instance.player.GetComponent<PlayerController>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.isDown = false;
    }
}
