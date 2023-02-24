using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecipeList : SlotList, IBackBtnHandler
{
    GameObject menu = default;
    void Awake()
    {
        menu = GameObject.Find("InitObjs").FindChildObj("Menu");   
    }
    void OnEnable()
    {
        menu.SetActive(false);
        SlotSet<Recipe>(Inventory.instance.recipes, "recipe");
        Back.clickBackBtn += OnBackBtnClick;
    }

    void OnDisable()
    {
        
    }

    public void OnBackBtnClick()
    {
        
    }
}
