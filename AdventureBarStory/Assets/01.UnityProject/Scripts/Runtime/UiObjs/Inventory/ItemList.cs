using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemList : SlotList
{
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
    public void OnClickRecipeBtn()
    {
        OnClickBtn("recipe");
    }

    void OnClickBtn(string _tag)
    {
        SlotReset();

        idx = 0;
        slotIdx = 0;

        switch (_tag)
        {
            case "material":
                SlotSet<Item>(Inventory.instance.materials, _tag);
                break;
            case "equip":
                SlotSet<Equip>(Inventory.instance.equips, _tag);
                break;
            case "potion":
                SlotSet<Potion>(Inventory.instance.potions, _tag);
                break;
            case "recipe":
                SlotSet<Recipe>(Inventory.instance.recipes, _tag);
                break;
        }
    }
}
