using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : SlotList
{
    [SerializeField]
    GameObject itemTooltip = default;
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

    public virtual void OnClickBtn(string _tag)
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

    public void OnDisable()
    {
        SlotReset();
        if(itemTooltip != default)
        {
            itemTooltip.GetComponent<TMP_Text>().text = "";
        }
    }
}
