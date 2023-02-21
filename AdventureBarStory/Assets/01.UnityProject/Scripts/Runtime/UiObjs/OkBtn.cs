using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkBtn : MonoBehaviour, IOKBtnHandler
{
    public static Action clickOkBtn = default;

    public void OnOkBtnClick()
    {
        clickOkBtn();
        Debug.Log("??");
        clickOkBtn = default;
    }
}
