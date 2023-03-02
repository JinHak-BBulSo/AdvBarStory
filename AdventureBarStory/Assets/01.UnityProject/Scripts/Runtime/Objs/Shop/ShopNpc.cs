using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNpc : MonoBehaviour
{
    GameObject shopObjs = default;
    [SerializeField]
    GameObject shop = default;
    GameObject okBtn = default;
    GameObject menu = default;

    void Awake()
    {
        okBtn = GameObject.Find("InitObjs").FindChildObj("OkBtn");
        menu = GameObject.Find("InitObjs").FindChildObj("Menu");
        shopObjs = GameObject.Find("ShopObjs");
        shop = shopObjs.FindChildObj("Shop");
    }

    public void OnOkBtnClick()
    {
        shop.SetActive(true);
        menu.SetActive(false);
        okBtn.SetActive(false);
        PlayerManager.instance.player.GetComponent<PlayerController>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            OkBtn.clickOkBtn -= OnOkBtnClick;
            OkBtn.clickOkBtn += OnOkBtnClick;

            okBtn.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            OkBtn.clickOkBtn -= OnOkBtnClick;

            okBtn.SetActive(false);
            menu.SetActive(true);
        }
    }
}
