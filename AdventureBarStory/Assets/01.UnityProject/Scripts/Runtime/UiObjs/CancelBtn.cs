using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelBtn : MonoBehaviour
{
    GameObject actionBtns = default;

    void Start()
    {
        actionBtns = transform.parent.gameObject.FindChildObj("BattleActionBtns");
    }

    public void OnCancelBtnClick()
    {
        OkBtn.clickOkBtn = default;
        actionBtns.SetActive(true);
    }
}
