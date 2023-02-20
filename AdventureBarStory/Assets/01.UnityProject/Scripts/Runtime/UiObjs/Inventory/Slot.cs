using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public int itemIdx = 0;
    public int itemAmount = 0;
    public Item slotItem = default;
    public TMP_Text tooltipTxt = default;

    void Start()
    {
        tooltipTxt = GameObject.Find("InitObjs").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();
    }

    public void OnClickSlot()
    {
        tooltipTxt.text = slotItem.toolTip;
    }
}
