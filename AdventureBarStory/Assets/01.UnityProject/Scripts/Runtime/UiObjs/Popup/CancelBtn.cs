using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelBtn : MonoBehaviour
{
    GameObject actionBtns = default;
    public static Action clickCancelBtn = default;

    void Start()
    {
        actionBtns = transform.parent.gameObject.FindChildObj("BattleActionBtns");
    }

    public void OnCancelBtnClick()
    {
        for (int i = 0; i < BattleManager.instance.battleTile.Count; i++)
        {
            BattleManager.instance.battleTile[i].GetComponent<Button>().enabled = false;
        }

        BattleCursor.battleTile = BattleManager.instance.nowTurnCharacter.onTileData;
        BattleCursor.battleTile.OnSelect();

        PlayerManager.instance.ActionReset();

        OkBtn.clickOkBtn = default;
        actionBtns.SetActive(true);

        if (clickCancelBtn == default) return;
        clickCancelBtn();
        clickCancelBtn = default;
    }
}
