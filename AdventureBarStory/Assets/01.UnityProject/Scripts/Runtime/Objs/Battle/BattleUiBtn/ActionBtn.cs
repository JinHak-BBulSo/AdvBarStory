using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBtn : MonoBehaviour, IOKBtnHandler
{
    [SerializeField]
    public GameObject battleActionObjs = default;
    public Player nowPlayer = default;
    [SerializeField]
    public GameObject okBtn = default;
    [SerializeField]
    public GameObject cancelBtn = default;

    void Start()
    {
        battleActionObjs = transform.parent.gameObject;
        okBtn = GameObject.Find("InitObjs").FindChildObj("OkBtn");
        cancelBtn = GameObject.Find("BattleObjs").FindChildObj("CancelBtn");
    }

    void OnEnable()
    {
        nowPlayer = BattleManager.instance.nowTurnPlayer;
        BattleCursor.battleTile = BattleManager.instance.nowTurnCharacter.onTileData;
        BattleCursor.battleTile.OnSelect();
    }
    public virtual void OnOkBtnClick()
    {
        PlayerManager.instance.ActionStart();
    }
}
