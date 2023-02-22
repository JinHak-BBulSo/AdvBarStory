using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBtn : MonoBehaviour, IOKBtnHandler, IBackBtnHandler
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
        battleActionObjs.SetActive(false);
        okBtn.SetActive(true);
        cancelBtn.SetActive(true);

        for(int i = 0; i < BattleManager.instance.battleTile.Count; i++)
        {
            BattleManager.instance.battleTile[i].GetComponent<Button>().enabled = true;
        }
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
