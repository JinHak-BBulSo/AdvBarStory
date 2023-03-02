using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmorSlot : PlayerEquipSlot
{
    void OnEnable()
    {
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        slotItem = player.equipArmor;

        if (slotItem != default)
        {
            equipNameTxt.text = slotItem.itemName;
            equipImage.sprite = slotItem.itemImage;
        }
    }
}
