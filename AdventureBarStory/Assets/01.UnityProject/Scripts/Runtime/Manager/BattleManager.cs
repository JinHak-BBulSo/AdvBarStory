using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    [SerializeField]
    GameObject battleObjsPrefab = default;
    public GameObject battleObjs = default;
    GameObject monsterObjs = default;
    GameObject playerObjs = default;

    [SerializeField]
    Sprite[] battleBgSprite = default;

    public List<Monster> monsters = new List<Monster>();
    public List<Player> players = new List<Player>();
    public Queue<Character> turnReadyCharacter = new Queue<Character>();
    public Queue<Player> turnReadyPlayer = new Queue<Player>();
    public Queue<Monster> turnReadyMonster = new Queue<Monster>();

    public bool isTurnStart = false;

    public int monsterIndex = 0;

    public Character nowTurnCharacter = default;
    public Player nowTurnPlayer = default;
    public Monster nowTurnMonster = default;

    public List<GameObject> monsterSlot = new List<GameObject>();
    public List<MonsterStatus> monsterStatuses = new List<MonsterStatus>();
    public Vector2[] monsterPos = default;

    public override void Awake()
    {
        if(instance == null)
        {
            battleObjs = Instantiate(battleObjsPrefab, transform);
            battleObjs.name = "BattleObjs";
            battleObjs.SetActive(false);
        }
        base.Awake();

        playerObjs = battleObjs.FindChildObj("PlayerObjs");
        monsterObjs = battleObjs.FindChildObj("MonsterObjs");

        for (int i = 0; i < playerObjs.transform.childCount; i++)
        {
            players.Add(playerObjs.transform.GetChild(i).GetComponent<Player>());
        }

        for(int i = 0; i < monsterObjs.transform.childCount; i++)
        {
            monsterSlot.Add(monsterObjs.transform.GetChild(i).gameObject);
            monsters.Add(monsterSlot[i].transform.GetChild(0).GetComponent<Monster>());
        }
    }

    void Update()
    {
        if (battleObjs.activeSelf)
        {
            if (turnReadyCharacter.Count == 0 && !isTurnStart)
            {
                turnCalculate();
            }
            else if (turnReadyCharacter.Count != 0 && !isTurnStart)
            {
                isTurnStart = true;
                nowTurnCharacter = turnReadyCharacter.Dequeue();
                TurnStart();
            }
        }
    }

    public void turnCalculate()
    {
        foreach(Player player in players)
        {
            if (player.isDie) continue;

            player.TurnRecovery();
            if(player.turnGuage >= 100)
            {
                player.turnGuage = 100;
                turnReadyCharacter.Enqueue(player);
                turnReadyPlayer.Enqueue(player);
            }
        }

        foreach(Monster monster in monsters)
        {
            if (monster.isDie) continue;

            monster.TurnRecovery();
            if (monster.turnGuage >= 100)
            {
                monster.turnGuage = 100;
                turnReadyCharacter.Enqueue(monster);
                turnReadyMonster.Enqueue(monster);
            }
        }
    }

    void TurnStart()
    {
        BattleCursor.battleTile = nowTurnCharacter.onTileData;
        BattleCursor.battleTile.OnSelect();


        if (nowTurnCharacter.gameObject.tag == "Player")
        {
            gameObject.FindChildObj("BattleBtnObjs").SetActive(true);
            nowTurnPlayer = turnReadyPlayer.Dequeue();
        }
        else
        {
            nowTurnMonster = turnReadyMonster.Dequeue();
            nowTurnMonster.Attack();
            StartCoroutine(TurnFinish());
        }
    }

    IEnumerator TurnFinish()
    {
        yield return new WaitForSeconds(1.5f);
        isTurnStart = false;
    }

    public void BattleStart()
    {
        MonsterSet();
        battleObjs.SetActive(true);
        for(int i = 0; i < monsterIndex; i++)
        {
            monsterSlot[i].SetActive(true);
        }
    }

    public void MonsterSet()
    {
        if(GFunc.GetActiveScene().name == "03.Stage1Scene")
        {
            //monsterIndex = Random.Range(1, 4 + 1);
            monsterIndex = 4;

            for(int i = 0; i <= monsterIndex - 1; i++)
            {
                int monsterId = Random.Range(0, 2 + 1);
                Debug.Log(monsterId);
                Debug.Log(i);
                monsterSlot[i].GetComponent<MonsterSlot>().SetMonster(monsterStatuses[monsterId]);
            }
        }
    }

    public void Win()
    {

    }

    public void Defeat()
    {

    }

    public void GetRanIndex(int num)
    {

    }
}
