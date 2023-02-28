using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public void TownRecall()
    {
        foreach(Player player in BattleManager.instance.playerParty)
        {
            player.RecallRecovery();
        }
    }

    public void GameOver()
    {

    }
}
