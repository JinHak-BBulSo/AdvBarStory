using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopList : ItemList
{
    GameObject menu = default;
    GameObject okBtn = default;
    GameObject backBtn = default;
    GameObject shopObjs = default;

    public override void Awake()
    {
        okBtn = GameObject.Find("InitObjs").FindChildObj("OkBtn");
        menu = GameObject.Find("InitObjs").FindChildObj("Menu");
        backBtn = GameObject.Find("InitObjs").FindChildObj("Back");
        shopObjs = GameObject.Find("ShopObjs").FindChildObj("Shop");
        
        base.Awake();
    }

    void OnEnable()
    {
        menu.SetActive(false);
        okBtn.SetActive(false);
        backBtn.SetActive(true);
    }

    private void Start()
    {
        shopObjs.SetActive(false);
    }

    public override void OnClickBtn(string _tag)
    {
        SlotReset();
        SlotPurchaseAbleCheck();

        switch (_tag)
        {
            case "material":
                SlotSet<Item>(Shop.instance.shopMaterials, _tag);
                break;
            case "equip":
                SlotSet<Equip>(Shop.instance.shopEquips, _tag);
                break;
            case "potion":
                SlotSet<Potion>(Shop.instance.shopPotions, _tag);
                break;
            case "recipe":
                SlotSet<Recipe>(Shop.instance.shopRecipes, _tag);
                break;
        }

        for (int i = 0; i < slotList.Count; i++)
        {
            if (!slotList[i].activeSelf) break;
            slotList[i].GetComponent<ShopSlot>().PurchaseAbleCheck();
        }
    }

    public override void SlotSet<T>(List<T> shopList, string _tag)
    {
        foreach (T item in shopList)
        {
            Slot slot = slotList[slotIdx].GetComponent<Slot>();
            slot.slotItem = item;

            int itemIndex = -1;

            switch (_tag)
            {
                case "material":
                    itemIndex = Inventory.instance.materials.IndexOf(item);
                    if (itemIndex == -1) break;
                    slot.itemAmount = Inventory.instance.materialAmount[itemIndex];
                    break;
                case "equip":
                    itemIndex = Inventory.instance.equips.IndexOf(item as Equip);
                    if (itemIndex == -1) break;
                    slot.itemAmount = Inventory.instance.equipAmount[itemIndex];
                    break;
                case "potion":
                    itemIndex = Inventory.instance.potions.IndexOf(item as Potion);
                    if (itemIndex == -1) break;
                    slot.itemAmount = Inventory.instance.potionAmount[itemIndex];
                    break;
                case "recipe":
                    itemIndex = Inventory.instance.recipes.IndexOf(item as Recipe);
                    if (itemIndex == -1) break;
                    slot.itemAmount = 1;
                    break;
            }

            slotNameTextList[slotIdx].text = item.itemName;
            slotImageList[slotIdx].sprite = item.itemImage;

            if (slot.transform.childCount > 2)
            {
                if (_tag == "recipe")
                {
                    if(slot.itemAmount == 1)
                    {
                        slotStockText[slotIdx].text = "보유";
                    }
                    else
                    {
                        slotStockText[slotIdx].text = "미보유";
                    }
                }
                else if (slot.itemAmount == 0)
                {

                    slotStockText[slotIdx].text = "";
                }
                else
                {
                    slotStockText[slotIdx].text = slot.itemAmount.ToString();
                }
            }

            slotList[slotIdx].SetActive(true);

            idx++;
            slotIdx++;
        }
    }

    public void SlotPurchaseAbleCheck()
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if (!slotList[i].activeSelf) return;
            slotList[i].GetComponent<ShopSlot>().PurchaseAbleCheck();
        }
    }
}
