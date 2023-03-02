using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : Singleton<BattleManager>, ITurnFinishHandler
{
    public bool isBattleStart = false;
    public GameObject currentCharIcon = default;

    [SerializeField]
    GameObject battleObjsPrefab = default;
    public GameObject battleObjs = default;

    GameObject monsterObjs = default;
    GameObject playerObjs = default;
    GameObject battleTileObjs = default;

    [SerializeField]
    Sprite[] battleBgSprite = default;

    public List<Monster> monsters = new List<Monster>();
    public List<GameObject> playerWeapons = new List<GameObject>();
    public List<GameObject> battleTile = new List<GameObject>();

    public Queue<Character> turnReadyCharacter = new Queue<Character>();
    public Queue<Player> turnReadyPlayer = new Queue<Player>();
    public Queue<Monster> turnReadyMonster = new Queue<Monster>();

    public bool isTurnStart = false;

    public int monsterIndex = 0;
    public int startMonsterIndex = 0;
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
        }

        base.Awake();

        playerObjs = battleObjs.FindChildObj("PlayerObjs");
        monsterObjs = battleObjs.FindChildObj("MonsterObjs");
        battleTileObjs = battleObjs.FindChildObj("BattleTile");
        currentCharIcon = battleObjs.FindChildObj("CurrentCharIcon");

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

    public void Start()
    {
        for (int i = 0; i < playerObjs.transform.childCount - 4; i++)
        {
            playerWeapons.Add(playerObjs.transform.GetChild(i).gameObject);
            PlayerManager.instance.playerParty.Add(playerObjs.transform.GetChild(i + 3).GetComponent<Player>());
            PlayerManager.instance.playerParty[i].InitskillSet();
        }
        battleObjs.SetActive(false);
    }

    void Update()
    {
        if (battleObjs.activeSelf)
        {
            if (turnReadyCharacter.Count == 0 && !isTurnStart && monsterIndex != 0)
            {
                TurnCalculate();
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
            return;
        }
    }

    public void TurnCalculate()
    {
        foreach(Player player in PlayerManager.instance.playerParty)
        {
            if (player.isDie) continue;

            player.TurnRecovery();
            if(player.turnGuage >= 10)
            {
                player.turnGuage = 10;
                turnReadyCharacter.Enqueue(player);
                turnReadyPlayer.Enqueue(player);
            }
        }

        foreach(Monster monster in monsters)
        {
            if (monster.isDie) continue;

            monster.TurnRecovery();
            if (monster.turnGuage >= 10)
            {
                monster.turnGuage = 10;
                turnReadyCharacter.Enqueue(monster);
                turnReadyMonster.Enqueue(monster);
            }
        }
    }

    void TurnStart()
    {
        currentCharIcon.GetComponent<Image>().sprite = nowTurnCharacter.charImgSlot.GetComponent<Image>().sprite;
        nowTurnCharacter.GetComponent<Character>().charImgSlot.SetActive(false);
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
        yield return new WaitForSeconds(2f);
        isTurnStart = false;
    }

    public void BattleStart()
    {
        PlayerManager.instance.player.GetComponent<PlayerController>().enabled = false;
        currentCharIcon.GetComponent<Image>().sprite = null;
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
            monsterIndex = Random.Range(2, 4 + 1);
            startMonsterIndex = monsterIndex;

            for (int i = 0; i <= monsterIndex - 1; i++)
            {
                int monsterId = Random.Range(0, 2 + 1);
                monsterSlot[i].GetComponent<MonsterSlot>().SetMonster(monsterStatuses[monsterId]);
                monsterSlot[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    public void playerPartySet()
    {
        for (int i = 0; i < PlayerManager.instance.playerParty.Count; i++)
        {
            if (PlayerManager.instance.playerParty[i].isDie) PlayerManager.instance.playerParty[i].gameObject.SetActive(false);
            else
            {
                playerIndex++;
                PlayerManager.instance.playerParty[i].turnGuage = 0;
                PlayerManager.instance.playerParty[i].gameObject.SetActive(true);
            }
        }
    }

    public void Win()
    {
        for (int i = 0; i < PlayerManager.instance.playerParty.Count; i++)
        {
            PlayerManager.instance.playerParty[i].turnGuage = 0;
            PlayerManager.instance.playerParty[i].animator.SetBool("isAttack", false);
            PlayerManager.instance.playerParty[i].animator.SetBool("isWin", true);
            PlayerManager.instance.playerParty[i].charImgSlot.GetRect().anchoredPosition = new Vector2(244, -324);
        }

        PlayerManager.instance.PlayerGetExp(startMonsterIndex * 5);

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

        Inventory.instance.SetGold(100);
        GetComponent<AudioSource>().Stop();
        Camera.main.GetComponent<AudioSource>().Play();
        StartCoroutine(Delay());  
    }

    public void Defeat()
    {
        GameManager.instance.GameOver();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < PlayerManager.instance.playerParty.Count; i++)
        {
            PlayerManager.instance.playerParty[i].animator.SetBool("isWin", false);
        }
        battleObjs.SetActive(false);
        PlayerManager.instance.player.GetComponent<PlayerController>().enabled = true;
    }
}
