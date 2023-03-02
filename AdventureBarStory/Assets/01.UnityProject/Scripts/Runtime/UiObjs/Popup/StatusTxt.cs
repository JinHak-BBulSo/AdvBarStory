using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusTxt : MonoBehaviour
{
    TMP_Text statusTxt = default;
    public int playerIndex = -1;
    Player player = default;
    void Awake()
    {
        statusTxt = gameObject.FindChildObj("StatusTxt").GetComponent<TMP_Text>();
        player = PlayerManager.instance.playerParty[playerIndex];
    }

    void OnEnable()
    {
        statusTxt.text = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}",
            player.status._str, player.status._vit, player.status._int, player.status._men,
            player.status._agi, player.status._hit, player.status._avd, player.status._luk);
    }
}
