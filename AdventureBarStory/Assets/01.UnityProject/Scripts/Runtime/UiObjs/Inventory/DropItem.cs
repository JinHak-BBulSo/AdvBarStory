using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropItem : MonoBehaviour
{
    public Item item = default;
    SpriteRenderer spriteRenderer = default;
    GameObject itemGetTxtObjs = default;
    TMP_Text itemGetTxt = default;
    Image itemImage = default;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.itemImage;

        itemGetTxtObjs = GameObject.Find("InitObjs").FindChildObj("ItemGetTxtObjs");
        itemGetTxt = itemGetTxtObjs.FindChildObj("ItemGetTxt").GetComponent<TMP_Text>();
        itemImage = itemGetTxtObjs.FindChildObj("ItemImage").GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Inventory.instance.GetItem(item);
            gameObject.SetActive(false);

            itemGetTxtObjs.SetActive(true);
            itemImage.sprite = item.itemImage;
            itemGetTxt.text = string.Format("      {0} Get\nAdd Inventory", item.name);
        }
    }
}
