using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField]
    GameObject playerPrefab = default;
    GameObject player = default;

    public Vector3 recallPlayerTownPos = default;
    public Vector3 recallCameraPos = default;

    public override void Awake()
    {
        /*if(instance == null)
        {
            player = Instantiate(playerPrefab);
            player.transform.parent = transform;
            player.transform.position = new Vector3(-0.5f, -3f, 0);
            player.gameObject.name = "Player";
            player.SetActive(false);
        }*/
        base.Awake();
    }
}
