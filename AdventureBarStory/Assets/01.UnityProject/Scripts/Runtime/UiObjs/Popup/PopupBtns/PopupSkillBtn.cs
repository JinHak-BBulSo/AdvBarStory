using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupSkillBtn : PopupBtn, IBackBtnHandler
{
    GameObject popupSkillObjs = default;

    public override void Awake()
    {
        base.Awake();
        popupSkillObjs = initObjs.FindChildObj("PopupSkillObjs");
    }
    public void OnClickSKillBtn()
    {
        popupBtnList.SetActive(false);
        popupInitObjs.SetActive(false);
        popupSkillObjs.SetActive(true);
        Back.clickBackBtn += OnBackBtnClick;
    }

    public void OnBackBtnClick()
    {
        popupSkillObjs.SetActive(false);
        popupBtnList.SetActive(true);
        popupInitObjs.SetActive(true);
    }
}
