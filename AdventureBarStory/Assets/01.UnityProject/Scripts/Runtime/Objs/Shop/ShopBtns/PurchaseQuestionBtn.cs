using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PurchaseQuestionBtn : MonoBehaviour
{
    GameObject purchaseQuestionBtn = default;
    public static Item purchaseItem = default;
    public static Slot slot = default;

    GameObject emergencyObjs = default;
    ShopList shopList = default;

    void Awake()
    {
        purchaseQuestionBtn = gameObject;
        emergencyObjs = GameObject.Find("ShopObjs").FindChildObj("EmergencyObjs");
        shopList = GameObject.Find("ShopObjs").FindChildObj("ShopList").GetComponent<ShopList>();
    }

    public void OnClickYes()
    {
        if(purchaseItem.tag == "recipe")
        {
            if(Inventory.instance.recipes.Contains(purchaseItem as Recipe))
            {
                emergencyObjs.SetActive(true);
                purchaseQuestionBtn.SetActive(false);
                return;
            }
        }

        Inventory.instance.SetGold(purchaseItem.price * -1);

        switch (purchaseItem.tag)
        {
            case "material":
                Inventory.instance.GetItem<Item>(purchaseItem);
                break;
            case "equip":
                Inventory.instance.GetItem<Equip>(purchaseItem as Equip);
                break;
            case "potion":
                Inventory.instance.GetItem<Potion>(purchaseItem as Potion);
                break;
            case "recipe":
                Inventory.instance.GetItem<Recipe>(purchaseItem as Recipe);
                break;
        }

        shopList.SlotPurchaseAbleCheck();
        slot.itemAmount += 1;
        slot.transform.GetChild(2).GetComponent<TMP_Text>().text = slot.itemAmount.ToString();
        Inventory.instance.invenAudio.Play();
        purchaseQuestionBtn.SetActive(false);
    }
    public void OnClickNo()
    {
        purchaseQuestionBtn.SetActive(false);
    }
}
