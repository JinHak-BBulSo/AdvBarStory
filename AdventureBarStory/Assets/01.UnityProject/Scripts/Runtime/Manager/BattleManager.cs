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
    public List<GameObject> playerWeapons = new List<GameObject>();
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

        for (int i = 0; i < playerObjs.transform.childCount - 3; i++)
        {
            playerWeapons.Add(playerObjs.transform.GetChild(i).gameObject);
            playerParty.Add(playerObjs.transform.GetChild(i + 3).GetComponent<Player>());
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
            if (turnReadyCharacter.Count == 0 && !isTurnStart && monsterIndex != 0)
            {
                turnCalculate();
            }
            else if (turnReadyCharacter.Count != 0 && !isTurnStart && monsterIndex != 0)
            {
                isTurnStart = true;
                nowTurnCharacter = turnReadyCharacter.Dequeue();
                TurnStart();
            }
        }

        if(isBattleStart && monsterIndex == 0 && !isTurnStart)
        {
            Win();
        }

        if(isBattleStart && playerIndex == 0 && !isTurnStart)
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
        playerPartySet();

        isBattleStart = true;
        Camera.main.GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
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

    public void playerPartySet()
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
            playerParty[i].animator.SetBool("isAttack", false);
            playerParty[i].animator.SetBool("isWin", true);
        }

        turnReadyCharacter.Clear();
        turnReadyMonster.Clear();
        turnReadyPlayer.Clear();

        nowTurnCharacter = default;
        nowTurnPlayer = default;
        nowTurnMonster = default;
        playerIndex = 0;
        
        isTurnStart = false;
        isBattleStart = false;

        foreach(GameObject weapon in playerWeapons)
        {
            weapon.SetActive(false);
        }

        GetComponent<AudioSource>().Stop();
        Camera.main.GetComponent<AudioSource>().Play();
        StartCoroutine(Delay());
    }

    public void Defeat()
    {
        isBattleStart = false;
        isTurnStart = false;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < playerParty.Count; i++)
        {
            playerParty[i].animator.SetBool("isWin", false);
        }
        battleObjs.SetActive(false);
    }
}
