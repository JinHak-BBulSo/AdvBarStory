using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopSlot : Slot, IDeselectHandler
{
    bool isPurchaseAble = true;
    bool isSelected = false;
    public GameObject purchaseQuestionObjs = default;

    public override void Awake()
    {
        /* Do nothing */
    }

    public void PurchaseAbleCheck()
    {
        if (slotItem.tag == "recipe")
        {
            if (Inventory.instance.recipes.Contains(slotItem as Recipe))
            {
                transform.GetChild(0).GetComponent<TMP_Text>().color = Color.red;
                isPurchaseAble = false;
            }
            else
            {
                if (slotItem.price > Inventory.instance.nowGold)
                {
                    transform.GetChild(0).GetComponent<TMP_Text>().color = Color.red;
                    isPurchaseAble = false;
                }
                else
                {
                    transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
                    isPurchaseAble = true;
                }
            }
        }
        else
        {
            if (slotItem.price > Inventory.instance.nowGold)
            {
                transform.GetChild(0).GetComponent<TMP_Text>().color = Color.red;
                isPurchaseAble = false;
            }
            else
            {
                transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
                isPurchaseAble = true;
            }
        }
    }

    public override void OnClickSlot()
    {
        if (!isSelected)
        {
            base.OnClickSlot();

            if (isPurchaseAble)
            {
                tooltipTxt.text += " 구매가능";
            }
            else
            {
                tooltipTxt.text += " 구매불가";
            }

            isSelected = true;
        }
        else if (isSelected)
        {
            if (isPurchaseAble)
            {
                PurchaseQuestionBtn.purchaseItem = slotItem;
                PurchaseQuestionBtn.slot = this;
                purchaseQuestionObjs.SetActive(true);
            }
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }

}
