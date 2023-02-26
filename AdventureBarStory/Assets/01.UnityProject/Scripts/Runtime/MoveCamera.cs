using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour, ICameraMoveHandler
{
    protected GameObject player = default;
    private GameObject okBtn = default;
    private GameObject menu = default;

    public virtual void Start()
    {
        player = GameObject.Find("PlayerManager").FindChildObj("Player");
        player.SetActive(true);

        okBtn = GameObject.Find("InitObjs").FindChildObj("OkBtn");
        okBtn.SetActive(false);

        menu = GameObject.Find("InitObjs").FindChildObj("Menu");
        menu.SetActive(true);
    }

    public virtual void OnCameraMove()
    {
        /* override using */
    }
}
