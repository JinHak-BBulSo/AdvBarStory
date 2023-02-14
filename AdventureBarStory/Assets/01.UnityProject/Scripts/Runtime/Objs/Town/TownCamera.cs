using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TownCamera : MonoBehaviour
{
    public bool isInBar = true;
    public bool isInStreet = false;
    public bool isInShop = false;

    private GameObject player = default;

    private void Awake()
    {
        player = GameObject.Find("Player");
        Camera.main.transform.position = new Vector3(0, player.transform.position.y, -10);
    }

    void Update()
    {
        CameraMove();
    }

    void CameraMove()
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
            if (player.transform.position.x > -50.5f && player.transform.position.x < -36.5f)
            {
                transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
            }

            if (player.transform.position.y > -19 && player.transform.position.y < 8.25)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, -10);
            }
        }
    }
}
