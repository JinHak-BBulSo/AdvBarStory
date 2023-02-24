using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public int itemAmount = 0;
    public Item slotItem = default;
    public TMP_Text tooltipTxt = default;

    public virtual void Start()
    {
        tooltipTxt = GameObject.Find("InitObjs").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();
    }

    public virtual void OnClickSlot()
    {
        tooltipTxt.text = slotItem.toolTip;
    }
}
