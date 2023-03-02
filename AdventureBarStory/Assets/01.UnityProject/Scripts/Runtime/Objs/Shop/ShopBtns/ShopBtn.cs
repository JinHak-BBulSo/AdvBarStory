using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBtn : MonoBehaviour
{
    public GameObject shopObjs = default;
    public GameObject shopBtnObjs = default;
    public GameObject shopItemList = default;
    public GameObject shopBtnList = default;

    public virtual void Awake()
    {
        shopObjs = GameObject.Find("ShopObjs");
        shopBtnObjs = shopObjs.FindChildObj("ShopBtnObjs");
        shopItemList = shopObjs.FindChildObj("ShopList");
        shopBtnList = shopObjs.FindChildObj("ShopBtns");
    }
}
