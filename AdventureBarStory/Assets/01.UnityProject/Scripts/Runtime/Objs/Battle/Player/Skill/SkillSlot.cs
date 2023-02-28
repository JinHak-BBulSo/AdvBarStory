using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillSlot : MonoBehaviour, IDeselectHandler
{
    bool isSelected = false;
    public int slotIndex = 0;

    GameObject skillObjs = default;

    void Start()
    {
        skillObjs = BattleManager.instance.battleObjs.FindChildObj("SkillObjs");
    }

    public void OnClickSkillSlot()
    {
        if (!isSelected)
        {
            isSelected = true;
        }
        else
        {
            switch (BattleManager.instance.nowTurnPlayer.name)
            {
                case "Siela":
                    Siela siela = BattleManager.instance.nowTurnPlayer as Siela;
                    siela.SkillSelect(slotIndex);
                    break;
                case "Fred":
                    Fred fred = BattleManager.instance.nowTurnPlayer as Fred;
                    fred.SkillSelect(slotIndex);
                    break;
                case "Alfine":
                    Alfine alfine = BattleManager.instance.nowTurnPlayer as Alfine;
                    alfine.SkillSelect(slotIndex);
                    break;
            }
            skillObjs.SetActive(false);
        } 
    }
    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = true;
    }
}
