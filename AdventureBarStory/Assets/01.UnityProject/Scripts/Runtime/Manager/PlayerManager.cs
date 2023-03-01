using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField]
    GameObject playerPrefab = default;
    public GameObject player = default;

    public List<Player> playerParty = new List<Player>();

    public Vector3 recallPlayerTownPos = default;
    public Vector3 recallCameraPos = default;

    public delegate void PlayerActionHandler();
    public event PlayerActionHandler PlayerAction;

    public override void Awake()
    {
        if (instance == null)
        {
            player = Instantiate(playerPrefab);
            player.transform.parent = transform;
            player.transform.position = new Vector3(-0.5f, -3f, 0);
            player.gameObject.name = "Player";
            player.SetActive(false);
        }
        base.Awake();
    }

    public void ActionStart()
    {
        if (PlayerAction == default) return;
        PlayerAction();
        ActionReset();
    }

    public void ActionReset()
    {
        PlayerAction = default;
    }

    public void EquipEquipment(Equip _equip, Player _player)
    {
        _player.status._hit += _equip._atk;
        _player.status._vit += _equip._def;
        _player.status._int += _equip._int;

        _player.equipWeapon = _equip;

        Inventory.instance.UseItem<Equip>(_equip, 1);
    }

    public void DismountEquipment(Equip _equip, Player _player)
    {
        _player.status._hit -= _equip._atk;
        _player.status._vit -= _equip._def;
        _player.status._int -= _equip._int;

        _player.equipWeapon = default;

        Inventory.instance.GetItem<Equip>(_equip);
    }
}
