using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupStatusBtn : PopupBtn, IBackBtnHandler
{
    GameObject popupStatusObjs = default;
    public override void Awake()
    {
        base.Awake();
        popupStatusObjs = initObjs.FindChildObj("PopupStatusObjs");
    }
    public void OnClickStatusBtn()
    {
        popupBtnList.SetActive(false);
        popupInitObjs.SetActive(false);
        popupStatusObjs.SetActive(true);

        Back.clickBackBtn += OnBackBtnClick;
    }

    public void OnBackBtnClick()
    {
        popupStatusObjs.SetActive(false);
        popupBtnList.SetActive(true);
        popupInitObjs.SetActive(true);
    }
}
