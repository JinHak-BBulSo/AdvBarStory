using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleCharSlot : MonoBehaviour
{
    [SerializeField]
    private Player player = default;
    public string charName = default;
    public bool firstEnable = false;

    [SerializeField]
    TMP_Text[] texts = new TMP_Text[3]; 

    public virtual void OnEnable()
    {
        if (!firstEnable)
        {
            firstEnable = true;
            return;
        }

        if(player == default)
        {
            player = GameObject.Find("BattleManager").FindChildObj(charName).GetComponent<Player>();
        }

        TextSet();
    }

    public virtual void TextSet()
    {
        //LV
        texts[0].text = player.level.ToString();

        //hp
        texts[1].text = player.nowHp.ToString() + " / " + player.status.hp.ToString();

        //mp
        texts[2].text = player.nowMp.ToString() + " / " + player.status.mp.ToString();
    }
}
