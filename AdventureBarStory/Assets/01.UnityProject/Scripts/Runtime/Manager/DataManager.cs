using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class DataManager : Singleton<DataManager>
{
    PlayerData[] playerDatas = new PlayerData[3];
    EventData eventData = default;
    InventoryData inventoryData = default;

    string sielaPath = default;
    string fredPath = default;
    string alfinePath = default;
    string eventPath = default;
    string inventoryPath = default;

    public override void Awake()
    {
        base.Awake();
        SetPath();
    }

    void SetPath()
    {
        sielaPath = Application.dataPath + "/" + "SaveData" + "/" + "SielaData";
        fredPath = Application.dataPath + "/" + "SaveData" + "/" + "FredData";
        alfinePath = Application.dataPath + "/" + "SaveData" + "/" + "AlfineData";
        eventPath = Application.dataPath + "/" + "SaveData" + "/" + "EventData";
        inventoryPath = Application.dataPath + "/" + "SaveData" + "/" + "InventoryData";
    }

    public void SaveJson()
    {
        string jsonSielaData = JsonUtility.ToJson(playerDatas[0]);
        string jsonFredData = JsonUtility.ToJson(playerDatas[1]);
        string jsonAlfineData = JsonUtility.ToJson(playerDatas[2]);
        string jsonEventData = JsonUtility.ToJson(eventData);
        string jsonInventoryData = JsonUtility.ToJson(inventoryData);
        
        File.WriteAllText(sielaPath, jsonSielaData);
        File.WriteAllText(fredPath, jsonFredData);
        File.WriteAllText(alfinePath, jsonAlfineData);
        File.WriteAllText(eventPath, jsonEventData);
        File.WriteAllText(inventoryPath, jsonInventoryData);
    }

    public void LoadJson()
    {
        playerDatas[0] = JsonUtility.FromJson<PlayerData>(sielaPath);
        playerDatas[1] = JsonUtility.FromJson<PlayerData>(fredPath);
        playerDatas[2] = JsonUtility.FromJson<PlayerData>(alfinePath);
        eventData = JsonUtility.FromJson<EventData>(eventPath);
        inventoryData = JsonUtility.FromJson<InventoryData>(inventoryPath);
    }

    public void SetPlayerData()
    {
        int index = 0;
        foreach(Player player in PlayerManager.instance.playerParty)
        {
            playerDatas[index]._str = player.status._str;
            playerDatas[index]._vit = player.status._vit;
            playerDatas[index]._int = player.status._int;
            playerDatas[index]._men = player.status._men;
            playerDatas[index]._agi = player.status._agi;
            playerDatas[index]._hit = player.status._hit;
            playerDatas[index]._avd = player.status._avd;
            playerDatas[index]._luk = player.status._luk;

            playerDatas[index].hp = player.status.hp;
            playerDatas[index].mp = player.status.mp;

            playerDatas[index].equipWeapon = player.equipWeapon;
            playerDatas[index].equipArmor = player.equipArmor;

            playerDatas[index].exp = player.exp;
            playerDatas[index].level = player.level;
        }
    }

    public void SetEventData()
    {
        eventData.isFinish = EventManager.instance.gameEvents[0].isFinish;
    }
    public void SetInventoryData()
    {
        inventoryData.nowGold = Inventory.instance.nowGold;

        inventoryData.allItems = Inventory.instance.allItems;

        inventoryData.materials = Inventory.instance.materials;
        inventoryData.materialAmount = Inventory.instance.materialAmount;

        inventoryData.equips = Inventory.instance.equips;
        inventoryData.equipAmount = Inventory.instance.equipAmount;

        inventoryData.foods = Inventory.instance.foods;
        inventoryData.foodAmount = Inventory.instance.foodAmount;

        inventoryData.potions = Inventory.instance.potions;
        inventoryData.potionAmount = Inventory.instance.potionAmount;

        inventoryData.recipes = Inventory.instance.recipes;
    }

    public class PlayerData
    {
        public int _str;
        public int _vit;
        public int _int;
        public int _men;
        public int _agi;
        public int _hit;
        public int _avd;
        public int _luk;

        public int hp;
        public int mp;

        public Equip equipWeapon;
        public Equip equipArmor;

        public int exp;
        public int level;
    }
    public class EventData
    {
        public bool isFinish;
    }

    public class InventoryData
    {
        public int nowGold = default;

        public List<Item> allItems = new List<Item>();

        public List<Item> materials = new List<Item>();
        public List<int> materialAmount = new List<int>();

        public List<Equip> equips = new List<Equip>();
        public List<int> equipAmount = new List<int>();

        public List<Food> foods = new List<Food>();
        public List<int> foodAmount = new List<int>();

        public List<Potion> potions = new List<Potion>();
        public List<int> potionAmount = new List<int>();

        public List<Recipe> recipes = new List<Recipe>();
    }
}
