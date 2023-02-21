using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBtn : MonoBehaviour, IOKBtnHandler, IBackBtnHandler
{
    [SerializeField]
    private GameObject battleBtnObjs = default;
    private Player nowPlayer = default;
    [SerializeField]
    private GameObject okBtn = default;
    [SerializeField]
    private GameObject cancelBtn = default;

    void Start()
    {
        battleBtnObjs = transform.parent.parent.gameObject;
        okBtn = GameObject.Find("BattleObjs").FindChildObj("OkBtn");
        cancelBtn = GameObject.Find("BattleObjs").FindChildObj("CancelBtn");
    }

    void OnEable()
    {
        nowPlayer = BattleManager.instance.nowTurnPlayer;
        BattleCursor.battleTile = BattleManager.instance.nowTurnCharacter.onTileData;
        BattleCursor.battleTile.OnSelect();
    }

    public void OnClickAttackBtn()
    {
        OkBtn.clickOkBtn += OnOkBtnClick;
        battleBtnObjs.SetActive(false);
        okBtn.SetActive(true);
        cancelBtn.SetActive(true);
    }

    public void OnBackBtnClick()
    {
        throw new System.NotImplementedException();
    }

    public void OnOkBtnClick()
    {
        BattleManager.instance.nowTurnPlayer.GetComponent<Player>().Attack();
    }
}
