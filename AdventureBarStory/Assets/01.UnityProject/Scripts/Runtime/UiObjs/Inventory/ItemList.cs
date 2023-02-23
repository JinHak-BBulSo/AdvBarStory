using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemList : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> slotList = default;
    public List<TMP_Text> slotTextList = default;
    public List<Image> slotImageList = default;

    [SerializeField]
    GameObject menu = default;

    private int idx = 0;
    private int slotIdx = 0;

    GameObject content = default;

    void Awake()
    {
        content = gameObject.FindChildObj("ItemSlots");
        for(int i = 0; i < content.transform.childCount; i++)
        {
            slotList.Add(content.transform.GetChild(i).gameObject);
            slotTextList.Add(content.transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>());
            slotImageList.Add(content.transform.GetChild(i).GetChild(1).GetComponent<Image>());
            slotList[i].SetActive(false);
        }

        menu = GameObject.Find("InitObjs").FindChildObj("Menu");
    }

    public void OnClickEquipBtn()
    {
        OnClickBtn("equip");
    }
    public void OnClickItemBtn()
    {
        OnClickBtn("potion");
    }
    public void OnClickMaterialBtn()
    {
        OnClickBtn("material");
    }

    void OnClickBtn(string _tag)
    {
        SlotReset();

        idx = 0;
        slotIdx = 0;

        switch (_tag)
        {
            case "material":
                foreach (var item in Inventory.instance.materials)
                {
                    if (item.tag != _tag)
                    {
                        idx++;
                        continue;
                    }

                    Slot slot = slotList[slotIdx].GetComponent<Slot>();
                    slot.slotItem = item;
                    slot.itemIdx = idx;
                    slot.itemAmount = Inventory.instance.materialAmount[idx];
                    slotTextList[slotIdx].text = item.itemName;
                    slotImageList[slotIdx].sprite = item.itemImage;
                    slotList[slotIdx].SetActive(true);

                    idx++;
                    slotIdx++;
                }
                break;
            case "equip":
                foreach (var item in Inventory.instance.equips)
                {
                    if (item.tag != _tag)
                    {
                        idx++;
                        continue;
                    }

                    Slot slot = slotList[slotIdx].GetComponent<Slot>();
                    slot.slotItem = item;
                    slot.itemIdx = idx;
                    slot.itemAmount = Inventory.instance.equipAmount[idx];
                    slotTextList[slotIdx].text = item.itemName;
                    slotImageList[slotIdx].sprite = item.itemImage;
                    slotList[slotIdx].SetActive(true);

                    idx++;
                    slotIdx++;
                }
                break;
            case "potion":
                foreach (var item in Inventory.instance.potions)
                {
                    if (item.tag != _tag)
                    {
                        idx++;
                        continue;
                    }

                    Slot slot = slotList[slotIdx].GetComponent<Slot>();
                    slot.slotItem = item;
                    slot.itemIdx = idx;
                    slot.itemAmount = Inventory.instance.potionAmount[idx];
                    slotTextList[slotIdx].text = item.itemName;
                    slotImageList[slotIdx].sprite = item.itemImage;
                    slotList[slotIdx].SetActive(true);

                    idx++;
                    slotIdx++;
                }
                break;
        }
    }

    void SlotReset()
    {
        foreach (GameObject _slot in slotList)
        {
            Slot slot = _slot.GetComponent<Slot>();
            slot.itemIdx = -1;
            slot.itemAmount = 0;
            slot.slotItem = default;
            _slot.SetActive(false);
        }
    }
}
