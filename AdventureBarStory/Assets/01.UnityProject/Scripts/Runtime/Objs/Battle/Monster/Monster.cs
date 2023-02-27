using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    private List<GameObject> playerParty = new List<GameObject>();
    private GameObject playerObjs = default;

    void OnEnable()
    {
        
    }

    void Start()
    {
        playerObjs = GameObject.Find("BattleObjs").FindChildObj("PlayerObjs");
        for(int i = 0; i < playerObjs.transform.childCount - 3; i++)
        {
            playerParty.Add(playerObjs.transform.GetChild(i + 3).gameObject);
        }
    }

    void Update()
    {
        
    }

    public override void Attack()
    {
        int playerId = TargetSelect();
        Player targetPlayer = playerParty[playerId].GetComponent<Player>();
        targetPlayer.Hit(status._hit);
        BattleCursor.battleTile = targetPlayer.onTileData;
        BattleCursor.battleTile.OnSelect();
        StartCoroutine(TurnFinish());
    }

    public override void Die()
    {
        BattleManager.instance.monsterIndex--;
        base.Die();
    }

    public int TargetSelect()
    {
        while (true)
        {
            int ran = Random.Range(0, 2 + 1);
            Player targetPlayer = playerParty[ran].GetComponent<Player>();

            if (!targetPlayer.isDie) return ran;
        }
    }
}
