using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipList : SlotList
{
    public override void Awake()
    {
        itemSlots = gameObject.FindChildObj("ItemSlots");
        for (int i = 0; i < itemSlots.transform.childCount - 1; i++)
        {
            slotList.Add(itemSlots.transform.GetChild(i).gameObject);
            slotNameTextList.Add(slotList[i].transform.GetChild(0).GetComponent<TMP_Text>());
            slotImageList.Add(slotList[i].transform.GetChild(1).GetComponent<Image>());

            if (slotList[i].transform.childCount > 2)
                slotStockText.Add(slotList[i].transform.GetChild(2).GetComponent<TMP_Text>());

            slotList[i].SetActive(false);
        }
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
    public void UpdateSlots()
    {
        SlotReset();
        SlotSet<Equip>(Inventory.instance.equips, "equip");
    }
}
