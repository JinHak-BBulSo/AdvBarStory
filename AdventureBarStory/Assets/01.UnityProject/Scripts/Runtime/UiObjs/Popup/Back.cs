using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour, IBackBtnHandler
{
    [SerializeField]
    GameObject menu = default;
    [SerializeField]
    GameObject popupUi = default;

    public static Action clickBackBtn = default;

    public void OnBackBtnClick()
    {
        if (clickBackBtn == default)
        {
            popupUi.SetActive(false);
            menu.SetActive(true);
            PlayerMoveBtns.instance.gameObject.SetActive(true);
            gameObject.SetActive(false);
            return;
        }
        clickBackBtn();
        clickBackBtn = default;
    }
}
