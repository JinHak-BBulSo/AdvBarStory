using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodSlot : Slot, IDeselectHandler
{
    public static FoodSlot nowSelectedFoodSlot = default;
    bool isSelected = false;
    GameObject EatQuestionObjs = default;

    public override void Awake()
    {
        tooltipTxt = GameObject.Find("InitObjs").FindChildObj("PopupEatObjs").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();
        EatQuestionObjs = GameObject.Find("InitObjs").FindChildObj("PopupEatObjs").FindChildObj("EatQuestionObjs");
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
            nowSelectedFoodSlot = this;
            EatQuestionObjs.SetActive(true);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }
}
