using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkBtn : MonoBehaviour, IOKBtnHandler
{
    public static Action clickOkBtn = default;

    public void OnOkBtnClick()
    {
        if (clickOkBtn == default) return;
        clickOkBtn();
        clickOkBtn = default;
    }

    void OnDisable()
    {
        clickOkBtn = default;
    }
}
