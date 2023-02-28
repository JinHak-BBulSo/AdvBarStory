using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ActionItemSlotObjs : SlotList
{
    private void OnEnable()
    {
        SlotReset();
        SlotSet<Potion>(Inventory.instance.potions, "potion");
    }
}
