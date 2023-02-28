using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBtn : ActionBtn, ICancelBtnHandler, IOKBtnHandler
{
    [SerializeField]
    private GameObject skillObjs = default;

    public void OnClickSkillBtn()
    {
        skillObjs.SetActive(true);
        CancelBtn.clickCancelBtn += OnCancelBtnClick;

        OkBtn.clickOkBtn += OnOkBtnClick;

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
        skillObjs.SetActive(false);
    }
}
