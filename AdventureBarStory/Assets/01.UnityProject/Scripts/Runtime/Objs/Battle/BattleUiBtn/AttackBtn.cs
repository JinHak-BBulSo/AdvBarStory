using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBtn : ActionBtn, IOKBtnHandler
{ 
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
}
