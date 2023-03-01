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
        PlayerManager.instance.DismountEquipment(EquipSlot.nowSelectedEquipSlot.player.equipWeapon, EquipSlot.nowSelectedEquipSlot.player);
        PlayerWeaponSlot slot = EquipSlot.nowSelectedEquipSlot as PlayerWeaponSlot;
        slot.UpdateSlot();
        equipList.UpdateSlots();
        EquipSlot.nowSelectedEquipSlot.SlotReSet();
        equipListObj.SetActive(false);
    }
}
