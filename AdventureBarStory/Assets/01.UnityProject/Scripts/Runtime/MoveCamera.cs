using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour, ICameraMoveHandler
{
    protected GameObject player = default;
    [SerializeField]
    private GameObject menu = default;

    public virtual void Start()
    {
        player = GameObject.Find("PlayerManager").FindChildObj("Player");
        player.SetActive(true);

        menu = GameObject.Find("InitObjs").FindChildObj("Menu");
        menu.SetActive(true);
    }

    public virtual void OnCameraMove()
    {
        /* override using */
    }
}
