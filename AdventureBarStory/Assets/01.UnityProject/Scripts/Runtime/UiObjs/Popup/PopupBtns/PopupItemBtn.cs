using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PopupItemBtn : PopupBtn, IBackBtnHandler
{
    public TMP_Text tooltipTxt = default;
    public GameObject itemBtnObjs = default;
    public GameObject itemList = default;

    public override void Awake()
    {
        base.Awake();
        itemBtnObjs = initObjs.FindChildObj("ItemBtnObjs");
        itemList = initObjs.FindChildObj("ItemList");
        tooltipTxt = GameObject.Find("InitObjs").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();
    }
    public void OnClickItemBtn()
    {
        itemBtnObjs.SetActive(true);
        itemList.SetActive(true);
        popupBtnList.SetActive(false);
        popupInitObjs.SetActive(false);

        tooltipTxt.text = string.Empty;
        Back.clickBackBtn += OnBackBtnClick;
    }

    public void OnBackBtnClick()
    {
        itemBtnObjs.SetActive(false);
        itemList.SetActive(false);
        popupBtnList.SetActive(true);
        popupInitObjs.SetActive(true);
    }

}
