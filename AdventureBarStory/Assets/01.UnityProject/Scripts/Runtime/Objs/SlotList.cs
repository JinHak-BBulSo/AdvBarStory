using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotList : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> slotList = new List<GameObject>();
    protected List<TMP_Text> slotNameTextList = new List<TMP_Text>();
    protected List<Image> slotImageList = new List<Image>();
    protected List<TMP_Text> slotStockText = new List<TMP_Text>();

    protected int idx = 0;
    protected int slotIdx = 0;

    GameObject itemSlots = default;

    public virtual void Awake()
    {
        itemSlots = gameObject.FindChildObj("ItemSlots");
        for (int i = 0; i < itemSlots.transform.childCount; i++)
        {
            slotList.Add(itemSlots.transform.GetChild(i).gameObject);
            slotNameTextList.Add(slotList[i].transform.GetChild(0).GetComponent<TMP_Text>());
            slotImageList.Add(slotList[i].transform.GetChild(1).GetComponent<Image>());

            if (slotList[i].transform.childCount > 2)
                slotStockText.Add(slotList[i].transform.GetChild(2).GetComponent<TMP_Text>());

            slotList[i].SetActive(false);
        }
    }

    public void SlotReset()
    {
        foreach (GameObject _slot in slotList)
        {
            Slot slot = _slot.GetComponent<Slot>();
            slot.itemAmount = 0;
            slot.slotItem = default;
            _slot.SetActive(false);
        }

        idx = 0;
        slotIdx = 0;
    }

    public virtual void SlotSet<T>(List<T> inventoryList, string _tag) where T : Item
    {
        foreach (T item in inventoryList)
        {
            Slot slot = slotList[slotIdx].GetComponent<Slot>();
            slot.slotItem = item;

            if (idx == inventoryList.Count) break;

            switch (_tag)
            {
                case "material":
                    slot.itemAmount = Inventory.instance.materialAmount[idx];
                    break;
                case "equip":
                    slot.itemAmount = Inventory.instance.equipAmount[idx];
                    break;
                case "potion":
                    slot.itemAmount = Inventory.instance.potionAmount[idx];
                    break;
                case "recipe":
                    slot.itemAmount = 1;
                    break;
            }

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
