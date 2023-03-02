using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSkillSlotList : MonoBehaviour
{
    public List<PopupSkillSlot> slotList = new List<PopupSkillSlot>();
    public Player player = default;
    public int playerIndex = -1;

    void Awake()
    {
        player = PlayerManager.instance.playerParty[playerIndex].GetComponent<Player>();

        for(int i = 0; i < transform.childCount; i++)
        {
            slotList.Add(transform.GetChild(i).GetComponent<PopupSkillSlot>());
        }

        
    }

    private void OnEnable()
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            slotList[i].tooltip = player.skillTooltip[i];
            slotList[i].skillNameTxt.text = player.skillInfo[i].Item1;
            slotList[i].skillMpTxt.text = player.skillInfo[i].Item2.ToString();
        }
    }
}
