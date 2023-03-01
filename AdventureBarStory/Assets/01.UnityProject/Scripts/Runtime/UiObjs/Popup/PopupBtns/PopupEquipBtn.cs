using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupEquipBtn : PopupBtn
{
    GameObject popupEquipObjs = default;
    public TMP_Text tooltipTxt = default;

    public override void Awake()
    {
        base.Awake();
        popupEquipObjs = initObjs.FindChildObj("PopupEquipObjs");
        tooltipTxt = GameObject.Find("InitObjs").FindChildObj("PopupEquipObjs").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();
    }
    public void OnClickEquipBtn()
    {
        popupBtnList.SetActive(false);
        popupInitObjs.SetActive(false);
        popupEquipObjs.SetActive(true);
        Back.clickBackBtn += OnBackBtnClick;
    }

    public void OnBackBtnClick()
    {
        tooltipTxt.text = string.Empty;
        popupEquipObjs.SetActive(false);
        popupBtnList.SetActive(true);
        popupInitObjs.SetActive(true);
    }
}
