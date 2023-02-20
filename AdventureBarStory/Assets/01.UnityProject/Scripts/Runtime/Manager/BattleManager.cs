using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    [SerializeField]
    Sprite[] battleBgSprite = default;
    public GameObject battleObjs = default;

    public int monsterIndex = 0;

    public void Win()
    {

    }

    public void Defeat()
    {

    }
}
