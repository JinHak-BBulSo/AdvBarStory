using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerEquipSlot : Slot, IDeselectHandler
{
    bool isSelected = false;
    public GameObject equipList = default;
    public Player player = default;
    public int playerIndex = -1;

    public TMP_Text equipNameTxt = default;
    public Image equipImage = default;

    public override void Awake()
    {
        tooltipTxt = GameObject.Find("InitObjs").FindChildObj("EquipTooltipObjs").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();
        equipList = GameObject.Find("InitObjs").FindChildObj("PopupEquipObjs").FindChildObj("EquipList");

        player = PlayerManager.instance.playerParty[playerIndex];

        equipNameTxt = transform.GetChild(0).GetComponent<TMP_Text>();
        equipImage = transform.GetChild(1).GetComponent<Image>();
    }

    public override void OnClickSlot()
    {
        if (!isSelected)
        {
            base.OnClickSlot();
            EquipSlot.nowSelectedEquipSlot = this;
            isSelected = true;
        }
        else
        {
            equipList.SetActive(true);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }
}
