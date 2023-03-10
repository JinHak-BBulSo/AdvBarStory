using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TownCamera : MoveCamera
{
    public bool isInBar = true;
    public bool isInStreet = false;
    public bool isInShop = false;

    public override void Start()
    {
        base.Start();

        PlayerMoveBtns.instance.gameObject.SetActive(true);
        if (PlayerManager.instance.recallCameraPos != default)
        {
            isInBar = false;
            isInStreet = true;
            transform.position = PlayerManager.instance.recallCameraPos;
            GameObject.Find("InitObjs").FindChildObj("WorldMap").SetActive(false);
        }
    }

    void Update()
    {
        OnCameraMove();
    }

    public override void OnCameraMove()
    {
        if (isInBar)
        {
            if (player.transform.position.y > -8.5f && player.transform.position.y < 0)
            {
                transform.position = new Vector3(0, player.transform.position.y, -10);
            }
        }

        if (isInStreet)
        {
            if (player.transform.position.x > -52.0f && player.transform.position.x < -35f)
            {
                transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
            }

            if (player.transform.position.y > -19 && player.transform.position.y < 8.25)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, -10);
            }
        }

        if (isInShop)
        {
            if (player.transform.position.y > -2f && player.transform.position.y < 0)
            {
                transform.position = new Vector3(30.5f, player.transform.position.y, -10);
            }
        }
    }
}
