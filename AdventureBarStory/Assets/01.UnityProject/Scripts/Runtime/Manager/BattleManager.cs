using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : Singleton<BattleManager>, ITurnFinishHandler
{
    public bool isBattleStart = false;
    public bool isBattleAble = true;

    [SerializeField]
    GameObject battleObjsPrefab = default;
    public GameObject battleObjs = default;

    GameObject monsterObjs = default;
    GameObject playerObjs = default;
    GameObject battleTileObjs = default;

    [SerializeField]
    Sprite[] battleBgSprite = default;

    public List<Monster> monsters = new List<Monster>();
    public List<Player> playerParty = new List<Player>();
    public List<GameObject> battleTile = new List<GameObject>();

    public Queue<Character> turnReadyCharacter = new Queue<Character>();
    public Queue<Player> turnReadyPlayer = new Queue<Player>();
    public Queue<Monster> turnReadyMonster = new Queue<Monster>();

    public bool isTurnStart = false;

    public int monsterIndex = 0;
    public int playerIndex = 0;

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
        battleTileObjs = battleObjs.FindChildObj("BattleTile");

        for (int i = 0; i < playerObjs.transform.childCount; i++)
        {
            playerParty.Add(playerObjs.transform.GetChild(i).GetComponent<Player>());
        }

        for(int i = 0; i < monsterObjs.transform.childCount; i++)
        {
            monsterSlot.Add(monsterObjs.transform.GetChild(i).gameObject);
            monsterSlot[i].transform.GetChild(0).gameObject.SetActive(false);
            monsters.Add(monsterSlot[i].transform.GetChild(0).GetComponent<Monster>());
        }

        for(int i = 0; i < battleTileObjs.transform.childCount; i++)
        {
            battleTile.Add(battleTileObjs.transform.GetChild(i).gameObject);
            battleTile[i].GetComponent<Button>().enabled = false;
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

        if(isBattleStart && monsterIndex == 0)
        {
            Win();
        }

        if(isBattleStart && playerIndex == 0)
        {
            Defeat();
        }
    }

    public void turnCalculate()
    {
        foreach(Player player in playerParty)
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
            for (int i = 0; i < battleTileObjs.transform.childCount; i++)
            {
                battleTile[i].GetComponent<Button>().enabled = false;
            }

            gameObject.FindChildObj("BattleActionBtns").SetActive(true);
            nowTurnPlayer = turnReadyPlayer.Dequeue();
        }
        else
        {
            nowTurnMonster = turnReadyMonster.Dequeue();
            nowTurnMonster.Attack();
            StartCoroutine(TurnFinish());
        }
    }

    public IEnumerator TurnFinish()
    {
        yield return new WaitForSeconds(1.5f);
        isTurnStart = false;
    }

    public void BattleStart()
    {
        MonsterSet();
        playerPartyet();

        isBattleStart = true;
        battleObjs.SetActive(true);
    }

    public void MonsterSet()
    {
        if(GFunc.GetActiveScene().name == "03.Stage1Scene")
        {
            monsterIndex = Random.Range(1, 4 + 1);

            for(int i = 0; i <= monsterIndex - 1; i++)
            {
                int monsterId = Random.Range(0, 2 + 1);
                monsterSlot[i].GetComponent<MonsterSlot>().SetMonster(monsterStatuses[monsterId]);
                monsterSlot[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    public void playerPartyet()
    {
        for (int i = 0; i < playerParty.Count; i++)
        {
            if (playerParty[i].isDie) playerParty[i].gameObject.SetActive(false);
            else
            {
                playerIndex++;
                playerParty[i].turnGuage = 0;
                playerParty[i].gameObject.SetActive(true);
            }
        }
    }

    public void Win()
    {
        for (int i = 0; i < playerParty.Count; i++)
        {
            playerParty[i].turnGuage = 0;
        }

        turnReadyCharacter.Clear();
        turnReadyMonster.Clear();
        turnReadyPlayer.Clear();

        nowTurnCharacter = default;
        nowTurnPlayer = default;
        nowTurnMonster = default;

        playerIndex = 0;
        battleObjs.SetActive(false);
        isTurnStart = false;
        isBattleStart = false;


    }

    public void Defeat()
    {
        isBattleStart = false;
        isTurnStart = false;
    }

    public void GetRanIndex(int num)
    {

    }

    IEnumerator BattleDelay()
    {
        isBattleAble = false;
        yield return new WaitForSeconds(5f);
        isBattleAble = true;
    }
}
