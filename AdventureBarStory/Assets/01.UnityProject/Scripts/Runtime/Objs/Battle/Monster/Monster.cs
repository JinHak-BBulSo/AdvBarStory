using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    private List<GameObject> playerParty = new List<GameObject>();
    private GameObject playerObjs = default;

    void Start()
    {
        playerObjs = GameObject.Find("BattleObjs").FindChildObj("PlayerObjs");
        for(int i = 0; i < playerObjs.transform.childCount; i++)
        {
            playerParty.Add(playerObjs.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void StatusSet()
    {
        base.StatusSet();
        status.mp = 0;
        status.hp = 50;
        status._str = 15;
        status._vit = 15;
        status._int = 0;
        status._men = 15;
        status._agi = 15;
        status._luk = 15;
    }
}
