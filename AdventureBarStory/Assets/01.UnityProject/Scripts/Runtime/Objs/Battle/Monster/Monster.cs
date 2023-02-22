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
        for(int i = 0; i < playerObjs.transform.childCount; i++)
        {
            playerParty.Add(playerObjs.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        
    }

    public override void Attack()
    {
        int ran = Random.Range(0, 2 + 1);
        Player targetPlayer = playerParty[ran].GetComponent<Player>();
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
}
