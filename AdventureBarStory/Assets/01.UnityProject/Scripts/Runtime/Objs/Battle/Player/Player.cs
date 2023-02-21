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

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {
        if (BattleCursor.battleTile != default)
        {
            BattleCursor.battleTile.onTileObject.GetComponent<Character>().Hit(status._hit);
            StartCoroutine(TurnFinish());
        }
    }
}
