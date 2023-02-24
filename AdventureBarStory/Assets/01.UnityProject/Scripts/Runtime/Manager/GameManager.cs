using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isGameOver = false;

    public void TownRecall()
    {
        foreach(Player player in BattleManager.instance.playerParty)
        {
            player.RecallRecovery();
        }
    }
}
