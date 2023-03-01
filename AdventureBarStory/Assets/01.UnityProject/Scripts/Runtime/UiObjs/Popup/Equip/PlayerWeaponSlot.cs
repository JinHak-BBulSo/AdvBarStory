using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSlot : PlayerEquipSlot
{
    void OnEnable()
    {
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        slotItem = player.equipWeapon;

        if (slotItem != default)
        {
            equipNameTxt.text = slotItem.itemName;
            equipImage.sprite = slotItem.itemImage;
        }
    }
}
