using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject gameOverObjs = default;
    public override void Awake()
    {
        base.Awake();
        gameOverObjs = GameObject.Find("InitObjs").FindChildObj("GameOverObjs");
    }
    public void TownRecall()
    {
        foreach(Player player in PlayerManager.instance.playerParty)
        {
            player.RecallRecovery();
        }
    }

    public void GameOver()
    {
        gameOverObjs.SetActive(true);
    }
}
