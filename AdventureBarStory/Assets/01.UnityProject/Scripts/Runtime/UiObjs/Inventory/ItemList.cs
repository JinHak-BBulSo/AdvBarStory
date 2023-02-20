using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        content = gameObject.FindChildObj("Content");
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

        foreach (Item item in Inventory.instance.haveItems)
        {
            if (item.tag != _tag)
            {
                idx++;
                continue;
            }

            Slot slot = slotList[slotIdx].GetComponent<Slot>();
            slot.slotItem = item;
            slot.itemIdx = idx;
            slot.itemAmount = Inventory.instance.itemAmountList[idx];
            slotTextList[slotIdx].text = item.itemName;
            slotImageList[slotIdx].sprite = item.itemImage;
            slotList[slotIdx].SetActive(true);

            idx++;
            slotIdx++;
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
