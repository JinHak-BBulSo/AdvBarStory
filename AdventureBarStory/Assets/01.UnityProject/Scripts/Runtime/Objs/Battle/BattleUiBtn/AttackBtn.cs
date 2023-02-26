using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBtn : MonoBehaviour, IOKBtnHandler
{
    [SerializeField]
    private GameObject battleActionObjs = default;
    private Player nowPlayer = default;
    [SerializeField]
    private GameObject okBtn = default;
    [SerializeField]
    private GameObject cancelBtn = default;

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
    public void PlayerAttack()
    {
        BattleManager.instance.nowTurnPlayer.GetComponent<Player>().Attack(); 
    }

    public void OnClickAttackBtn()
    {
        PlayerManager.instance.PlayerAction += PlayerAttack;
        OkBtn.clickOkBtn += OnOkBtnClick;

        for (int i = 0; i < BattleManager.instance.battleTile.Count; i++)
        {
            BattleManager.instance.battleTile[i].GetComponent<Button>().enabled = true;
        }

        battleActionObjs.SetActive(false);
        okBtn.SetActive(true);
        cancelBtn.SetActive(true);
    }

    public void OnOkBtnClick()
    {
        PlayerManager.instance.ActionStart();
    }
}
