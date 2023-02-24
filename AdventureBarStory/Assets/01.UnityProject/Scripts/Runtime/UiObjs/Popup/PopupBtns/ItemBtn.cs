using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBtn : PopupBtn, IBackBtnHandler
{
    public void OnClickItemBtn()
    {
        itemBtnObjs.SetActive(true);
        itemList.SetActive(true);
        popupBtnList.SetActive(false);
        popupInitObjs.SetActive(false);

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
