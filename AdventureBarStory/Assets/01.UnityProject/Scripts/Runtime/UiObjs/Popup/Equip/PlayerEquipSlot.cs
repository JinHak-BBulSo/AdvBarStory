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

    public Sprite nullImg = default;

    public override void Awake()
    {
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

    public void SlotReSet()
    {
        equipNameTxt.text = "Empty";
        equipImage.sprite = nullImg;
    }
}
