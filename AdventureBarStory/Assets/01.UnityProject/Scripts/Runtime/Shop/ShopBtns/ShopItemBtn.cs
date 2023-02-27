using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItemBtn : ShopBtn
{
    public TMP_Text tooltipTxt = default;

    public override void Awake()
    {
        base.Awake();
        tooltipTxt = GameObject.Find("ShopObjs").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();
    }
    public void OnClickItemBtn()
    {
        shopBtnObjs.SetActive(true);
        shopItemList.SetActive(true);
        shopBtnList.SetActive(false);

        tooltipTxt.text = string.Empty;
        Back.clickBackBtn += OnBackBtnClick;
    }

    public void OnBackBtnClick()
    {
        shopBtnObjs.SetActive(false);
        shopItemList.SetActive(false);
        shopBtnList.SetActive(true);
    }
}
