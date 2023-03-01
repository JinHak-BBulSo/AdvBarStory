using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipList : SlotList
{
    public override void Awake()
    {
        base.Awake();

    }
    void OnEnable()
    {
        SlotReset();
        SlotSet<Equip>(Inventory.instance.equips, "equip");
    }
    void OnDisable()
    {
        EquipSlot.nowSelectedEquipSlot = default;
    }
    public override void SlotSet<T>(List<T> inventoryList, string _tag)
    {
        foreach (T item in inventoryList)
        {
            Slot slot = slotList[slotIdx].GetComponent<Slot>();
            slot.slotItem = item;

            if (idx == inventoryList.Count) break;

            slot.itemAmount = Inventory.instance.equipAmount[idx];

            slotNameTextList[slotIdx].text = item.itemName;
            slotImageList[slotIdx].sprite = item.itemImage;

            if (slot.transform.childCount > 2)
                slotStockText[slotIdx].text = slot.itemAmount.ToString();

            slotList[slotIdx].SetActive(true);

            idx++;
            slotIdx++;
        }
    }

}
