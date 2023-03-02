using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupEatBtn : PopupBtn
{
    GameObject popupEatObjs = default;
    public override void Awake()
    {
        base.Awake();
        popupEatObjs = initObjs.FindChildObj("PopupEatObjs");
    }
    public void OnClickEatBtn()
    {
        popupBtnList.SetActive(false);
        popupInitObjs.SetActive(false);
        popupEatObjs.SetActive(true);

        Back.clickBackBtn += OnBackBtnClick;
    }

    public void OnBackBtnClick()
    {
        popupEatObjs.SetActive(false);
        popupBtnList.SetActive(true);
        popupInitObjs.SetActive(true);
    }
}
