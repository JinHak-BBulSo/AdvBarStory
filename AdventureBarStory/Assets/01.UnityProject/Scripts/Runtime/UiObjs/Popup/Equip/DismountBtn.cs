using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DismountBtn : MonoBehaviour
{
    GameObject equipListObj = default;
    EquipList equipList = default;

    void Awake()
    {
        equipListObj = GameObject.Find("InitObjs").FindChildObj("PopupEquipObjs").FindChildObj("EquipList");
        equipList = equipListObj.GetComponent<EquipList>();
    }
    public void OnClickDismountBtn()
    {
        if (EquipSlot.nowSelectedEquipSlot.name == "PlayerWeaponSlot")
        {
            PlayerManager.instance.DismountEquipment(EquipSlot.nowSelectedEquipSlot.player.equipWeapon, EquipSlot.nowSelectedEquipSlot.player);
            PlayerWeaponSlot slot = EquipSlot.nowSelectedEquipSlot as PlayerWeaponSlot;
            slot.UpdateSlot();
        }
        else
        {
            PlayerManager.instance.DismountEquipment(EquipSlot.nowSelectedEquipSlot.player.equipArmor, EquipSlot.nowSelectedEquipSlot.player);
            PlayerArmorSlot slot = EquipSlot.nowSelectedEquipSlot as PlayerArmorSlot;
            slot.UpdateSlot();
        }
        
        equipList.UpdateSlots();
        EquipSlot.nowSelectedEquipSlot.SlotReSet();
        equipListObj.SetActive(false);
    }
}
