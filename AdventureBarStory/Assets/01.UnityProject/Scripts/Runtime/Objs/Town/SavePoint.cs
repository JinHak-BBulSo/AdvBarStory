using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour, IOKBtnHandler
{
    public GameObject saveQuestionObjs = default;
    public GameObject okBtn = default;

    void Start()
    {
        okBtn = GameObject.Find("InitObjs").FindChildObj("OkBtn");
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

            okBtn.SetActive(false);
        }
    }

    public void OnOkBtnClick()
    {
        saveQuestionObjs.SetActive(true);
    }
}
