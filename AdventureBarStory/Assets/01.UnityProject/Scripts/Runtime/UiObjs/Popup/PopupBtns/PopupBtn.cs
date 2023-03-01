using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBtn : MonoBehaviour
{
    public GameObject initObjs = default;
    public GameObject popupBtnList = default;
    public GameObject popupInitObjs = default;
    
    public virtual void Awake()
    {
        initObjs = GameObject.Find("InitObjs");
        popupBtnList = initObjs.FindChildObj("ButtonList");
        popupInitObjs = initObjs.FindChildObj("PopupInitObjs");
    }
}
