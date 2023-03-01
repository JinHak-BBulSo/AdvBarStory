using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupLoadBtn : PopupBtn
{
    GameObject popupLoadObjs = default;
    public override void Awake()
    {
        base.Awake();
        popupLoadObjs = initObjs.FindChildObj("PopupLoadObjs");
    }
    public void OnClickLoadBtn()
    {
        popupBtnList.SetActive(false);
        popupInitObjs.SetActive(false);
        popupLoadObjs.SetActive(true);

        Back.clickBackBtn += OnBackBtnClick;
    }

    public void OnBackBtnClick()
    {
        popupLoadObjs.SetActive(false);
        popupBtnList.SetActive(true);
        popupInitObjs.SetActive(true);
    }
}
