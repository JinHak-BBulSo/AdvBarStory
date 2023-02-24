using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int exp = 0;
    public int level = 1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Attack()
    {
        if (BattleCursor.battleTile.onTileObject != default)
        {
            BattleCursor.battleTile.onTileObject.GetComponent<Character>().Hit(status._hit);
            StartCoroutine(TurnFinish());
        }
    }

    public void RecallRecovery()
    {
        nowHp = status.hp;
        nowMp = status.mp;
        turnGuage = 0;
        isDie = false;
        isTurnFinish = false;
    }
}
