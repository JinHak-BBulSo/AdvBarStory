using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodList : SlotList
{
    void OnEnable()
    {
        SlotReset();
        SlotSet<Food>(Inventory.instance.foods, "food");
    }

    public override void SlotSet<T>(List<T> inventoryList, string _tag)
    {
        foreach (T item in inventoryList)
        {
            Slot slot = slotList[slotIdx].GetComponent<Slot>();
            slot.slotItem = item;

            if (idx == inventoryList.Count) break;

            slot.itemAmount = Inventory.instance.foodAmount[idx];

            slotNameTextList[slotIdx].text = item.itemName;
            slotImageList[slotIdx].sprite = item.itemImage;

            if (slot.transform.childCount > 2)
                slotStockText[slotIdx].text = slot.itemAmount.ToString();

            slotList[slotIdx].SetActive(true);

            idx++;
            slotIdx++;
        }
    }
    public void UpdateSlots()
    {
        SlotReset();
        SlotSet<Food>(Inventory.instance.foods, "food");
    }
}
