using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillSlotObjs : MonoBehaviour
{
    public List<GameObject> skillSlot = new List<GameObject>();
    public List<TMP_Text> skillNames = new List<TMP_Text>();
    public List<TMP_Text> skillMps = new List<TMP_Text>();

    void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            skillSlot.Add(transform.GetChild(i).gameObject);
            skillNames.Add(skillSlot[i].transform.GetChild(0).GetComponent<TMP_Text>());
            skillMps.Add(skillSlot[i].transform.GetChild(1).GetComponent<TMP_Text>());

            skillSlot[i].SetActive(false);
        }
    }

    void OnEnable()
    {
        for(int i = 0; i < BattleManager.instance.nowTurnPlayer.skillInfo.Count; i++)
        {
            skillNames[i].text = BattleManager.instance.nowTurnPlayer.skillInfo[i].Item1;
            skillMps[i].text = BattleManager.instance.nowTurnPlayer.skillInfo[i].Item2.ToString();

            skillSlot[i].SetActive(true);
        }
    }
}
