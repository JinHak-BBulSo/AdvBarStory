using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipSlot : Slot, IDeselectHandler
{
    public static PlayerEquipSlot nowSelectedEquipSlot = default;
    bool isSelected = false;
    GameObject equipList = default;
    public override void Awake()
    {
        tooltipTxt = GameObject.Find("InitObjs").FindChildObj("PopupEquipObjs").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();
        equipList = GameObject.Find("InitObjs").FindChildObj("PopupEquipObjs").FindChildObj("EquipList");
    }

    public override void OnClickSlot()
    {
        if (!isSelected)
        {
            isSelected = true;
            base.OnClickSlot();
        }
        else
        {
            Equip equipment = slotItem as Equip;
            if(nowSelectedEquipSlot.name == "PlayerWeaponSlot")
            {
                if(equipment.equipTag == "weapon")
                {
                    nowSelectedEquipSlot.player.equipWeapon = equipment;
                    Inventory.instance.UseItem<Equip>(equipment, 1);

                    if(nowSelectedEquipSlot.player.equipWeapon == default)
                    {
                        PlayerManager.instance.EquipEquipment(equipment, nowSelectedEquipSlot.player);
                    }
                    else
                    {
                        PlayerManager.instance.DismountEquipment(nowSelectedEquipSlot.player.equipWeapon, nowSelectedEquipSlot.player);
                        PlayerManager.instance.EquipEquipment(equipment, nowSelectedEquipSlot.player);
                    }
                    PlayerWeaponSlot slot = nowSelectedEquipSlot as PlayerWeaponSlot;
                    slot.UpdateSlot();
                    equipList.SetActive(false);
                }
                else
                {
                    equipList.SetActive(false);
                    tooltipTxt.text = "This is not Weapon";
                }
            }
            else if(nowSelectedEquipSlot.name == "PlayerArmorSlot")
            {
                if (equipment.equipTag == "armor")
                {
                    nowSelectedEquipSlot.player.equipArmor = equipment;
                    Inventory.instance.UseItem<Equip>(equipment, 1);

                    if (nowSelectedEquipSlot.player.equipArmor == default)
                    {
                        PlayerManager.instance.EquipEquipment(equipment, nowSelectedEquipSlot.player);
                    }
                    else
                    {
                        PlayerManager.instance.DismountEquipment(nowSelectedEquipSlot.player.equipArmor, nowSelectedEquipSlot.player);
                        PlayerManager.instance.EquipEquipment(equipment, nowSelectedEquipSlot.player);
                    }
                    PlayerArmorSlot slot = nowSelectedEquipSlot as PlayerArmorSlot;
                    slot.UpdateSlot();
                    equipList.SetActive(false);
                }
                else
                {
                    equipList.SetActive(false);
                    tooltipTxt.text = "This is not Armor";
                }
            }
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }
}
