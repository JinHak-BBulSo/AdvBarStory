using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionItemBtn : ActionBtn, ICancelBtnHandler
{
    [SerializeField]
    private GameObject acctionItemObjs = default;

    public void OnClickActionItemBtn()
    {
        acctionItemObjs.SetActive(true);
        battleActionObjs.SetActive(false);

        OkBtn.clickOkBtn += OnOkBtnClick;
        CancelBtn.clickCancelBtn += OnCancelBtnClick;

        for (int i = 0; i < BattleManager.instance.battleTile.Count; i++)
        {
            BattleManager.instance.battleTile[i].GetComponent<Button>().enabled = true;
        }

        battleActionObjs.SetActive(false);
        okBtn.SetActive(true);
        cancelBtn.SetActive(true);
    }

    public void OnCancelBtnClick()
    {
        acctionItemObjs.SetActive(false);
    }
}
