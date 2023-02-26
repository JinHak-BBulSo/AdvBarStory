using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OvenUiSetter : MonoBehaviour, IOKBtnHandler, IBackBtnHandler
{
    GameObject ovenCookObjs = default;
    GameObject cookobjs = default;
    GameObject backBtn = default;
    GameObject okBtn = default;
    public TMP_Text tooltipTxt = default;

    void Start()
    {
        ovenCookObjs = GameObject.Find("OvenCookObjs");
        cookobjs = ovenCookObjs.FindChildObj("CookObjs");
        backBtn = GameObject.Find("InitObjs").FindChildObj("Back");
        okBtn = GameObject.Find("InitObjs").FindChildObj("OkBtn");
        tooltipTxt = GameObject.Find("OvenCookObjs").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();
    }

    public void OnOkBtnClick()
    {
        backBtn.SetActive(true);
        cookobjs.SetActive(true);

        Back.clickBackBtn -= OnBackBtnClick;
        Back.clickBackBtn += OnBackBtnClick;

        okBtn.SetActive(false);
    }

    public void OnBackBtnClick()
    {
        cookobjs.SetActive(false);
        backBtn.SetActive(false);
        okBtn.SetActive(true);

        tooltipTxt.text = string.Empty;

        OkBtn.clickOkBtn -= OnOkBtnClick;
        OkBtn.clickOkBtn += OnOkBtnClick;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OkBtn.clickOkBtn -= OnOkBtnClick;
            OkBtn.clickOkBtn += OnOkBtnClick;
            
            okBtn.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OkBtn.clickOkBtn -= OnOkBtnClick;
            Back.clickBackBtn -= OnBackBtnClick;

            okBtn.SetActive(false);
        }
    }
}
