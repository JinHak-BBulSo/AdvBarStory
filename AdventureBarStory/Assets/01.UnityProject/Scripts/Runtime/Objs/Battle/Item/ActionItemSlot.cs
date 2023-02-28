using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionItemSlot : Slot, IDeselectHandler
{
    bool isSelected = false;
    [SerializeField]
    GameObject actionItemObjs = default;
    GameObject battleActionBtns = default;

    public override void Awake()
    {
        tooltipTxt = GameObject.Find("BattleManager").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();
        actionItemObjs = transform.parent.parent.gameObject;
        battleActionBtns = GameObject.Find("BattleManager").FindChildObj("BattleActionBtns");
    }
    public override void OnClickSlot()
    {
        tooltipTxt.text = slotItem.toolTip;
        if (!isSelected)
        {
            isSelected = true;
        }
        else
        {
            PlayerManager.instance.PlayerAction += this.UsePotion;
            actionItemObjs.SetActive(false);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }

    public void UsePotion()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag == "Player")
        {
            Potion potion = slotItem as Potion;
            BattleCursor.battleTile.onTileObject.GetComponent<Player>().Recovery(potion.recoveryHp, potion.recoveryMp);

            Inventory.instance.UseItem<Potion>(slotItem as Potion, 1);
            battleActionBtns.SetActive(true);
        }
    }
}
