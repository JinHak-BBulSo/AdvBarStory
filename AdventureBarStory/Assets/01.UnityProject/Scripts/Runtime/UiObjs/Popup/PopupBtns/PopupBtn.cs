using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBtn : MonoBehaviour
{
    public GameObject initObjs = default;
    public GameObject itemBtnObjs = default;
    public GameObject itemList = default;
    public GameObject popupBtnList = default;
    public GameObject popupInitObjs = default;
    
    public void Awake()
    {
        initObjs = GameObject.Find("InitObjs");
        itemBtnObjs = initObjs.FindChildObj("ItemBtnObjs");
        itemList = initObjs.FindChildObj("ItemList");
        popupBtnList = initObjs.FindChildObj("ButtonList");
        popupInitObjs = initObjs.FindChildObj("PopupInitObjs");
    }
}
