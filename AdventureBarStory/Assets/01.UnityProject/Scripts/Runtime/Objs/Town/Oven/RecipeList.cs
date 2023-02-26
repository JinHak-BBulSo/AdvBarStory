using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecipeList : SlotList
{
    GameObject menu = default;
    GameObject okBtn = default;
    GameObject backBtn = default;

    GameObject recipeInfoList = default;
    List<Slot> infoSlots = new List<Slot>();

    public override void Awake()
    {
        okBtn = GameObject.Find("InitObjs").FindChildObj("OkBtn");
        menu = GameObject.Find("InitObjs").FindChildObj("Menu");
        backBtn = GameObject.Find("InitObjs").FindChildObj("Back");

        base.Awake();

        recipeInfoList = GameObject.Find("OvenCookObjs").FindChildObj("RecipeInfoList");
        for (int i = 0; i < recipeInfoList.FindChildObj("ItemSlots").transform.childCount; i++)
        {
            infoSlots.Add(recipeInfoList.FindChildObj("ItemSlots").transform.GetChild(i).GetComponent<Slot>());
            infoSlots[i].gameObject.SetActive(false);
        }

        SlotReset();
        SlotSet<Recipe>(Inventory.instance.recipes, "recipe");
    }
    void OnEnable()
    {
        menu.SetActive(false);
        okBtn.SetActive(false);
        backBtn.SetActive(true);

        SlotReset();
        SlotSet<Recipe>(Inventory.instance.recipes, "recipe");

        for(int i = 0; i < slotList.Count; i++)
        {
            if (!slotList[i].activeSelf) break;
            slotList[i].GetComponent<RecipeSlot>().RecipeCreateCheck();
        }

        for (int i = 0; i < infoSlots.Count; i++)
        {
            infoSlots[i].gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        menu.SetActive(true);
        okBtn.SetActive(true);
        backBtn.SetActive(false);
    }
}
