using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System;
using Unity.VisualScripting.FullSerializer;

public class DataManager : Singleton<DataManager>
{
    PlayerData[] playerDatas = new PlayerData[3];
    EventData eventData = new EventData();
    InventoryData inventoryData = new InventoryData();

    string sielaPath = default;
    string fredPath = default;
    string alfinePath = default;
    string eventPath = default;
    string inventoryPath = default;

    public bool isSaveDataExist = false;
    public string jsonText = default;

    public override void Awake()
    {
        base.Awake();
        SetPath();
        
        playerDatas[0] = new PlayerData();
        playerDatas[1] = new PlayerData();
        playerDatas[2] = new PlayerData();
    }

    void Start()
    {
        DataExistCheck();
    }

    void SetPath()
    {
        sielaPath = Application.persistentDataPath + "/" + "SielaData";
        fredPath = Application.persistentDataPath + "/" + "FredData";
        alfinePath = Application.persistentDataPath + "/" + "AlfineData";
        eventPath = Application.persistentDataPath + "/" + "EventData";
        inventoryPath = Application.persistentDataPath + "/" + "InventoryData";
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
        jsonText = File.ReadAllText(sielaPath);
        playerDatas[0] = JsonUtility.FromJson<PlayerData>(jsonText);

        jsonText = File.ReadAllText(fredPath);
        playerDatas[1] = JsonUtility.FromJson<PlayerData>(jsonText);

        jsonText = File.ReadAllText(alfinePath);
        playerDatas[2] = JsonUtility.FromJson<PlayerData>(jsonText);

        jsonText = File.ReadAllText(eventPath);
        eventData = JsonUtility.FromJson<EventData>(jsonText);

        jsonText = File.ReadAllText(inventoryPath);
        inventoryData = JsonUtility.FromJson<InventoryData>(jsonText);
    }

    public void DataExistCheck()
    {
        try
        {
            jsonText = File.ReadAllText(eventPath);
            eventData = JsonUtility.FromJson<EventData>(jsonText);
            isSaveDataExist = true;
        }
        catch (FileNotFoundException e)
        {
            isSaveDataExist = false;
            //Debug.Log(e.ToString());
        }  
    }

    public void OverlapData()
    {
        for (int i = 0; i < playerDatas.Length; i++)
        {
            Player player = PlayerManager.instance.playerParty[i];
            player.status._str = playerDatas[i]._str;
            player.status._vit = playerDatas[i]._vit;
            player.status._int = playerDatas[i]._int;
            player.status._men = playerDatas[i]._men;
            player.status._agi = playerDatas[i]._agi;
            player.status._hit = playerDatas[i]._hit;
            player.status._avd = playerDatas[i]._avd;
            player.status._luk = playerDatas[i]._luk;

            player.status.hp = playerDatas[i].hp;
            player.status.mp = playerDatas[i].mp;

            if (playerDatas[i].equipWeaponId == -1)
            {
                player.equipWeapon = default;
            }
            else
            {
                player.equipWeapon = Inventory.instance.allItems[playerDatas[i].equipWeaponId] as Equip;
            }

            if (playerDatas[i].equipArmorId == -1)
            {
                player.equipArmor = default;
            }
            else
            {
                player.equipArmor = Inventory.instance.allItems[playerDatas[i].equipArmorId] as Equip;
            }

            player.exp = playerDatas[i].exp;
            player.level = playerDatas[i].level;
        }

        EventManager.instance.gameEvents[0].isFinish = eventData.isFinish;

        Inventory.instance.nowGold = inventoryData.nowGold;

        Inventory.instance.materials.Clear();
        Inventory.instance.materialAmount.Clear();
        for (int i = 0; i < inventoryData.materialsId.Count; i++)
        {
            Inventory.instance.materials.Add(Inventory.instance.allItems[inventoryData.materialsId[i]]);
            Inventory.instance.materialAmount.Add(inventoryData.materialAmount[i]);
        }

        Inventory.instance.equips.Clear();
        Inventory.instance.equipAmount.Clear();
        for (int i = 0; i < inventoryData.equipsId.Count; i++)
        {
            Inventory.instance.equips.Add(Inventory.instance.allItems[inventoryData.equipsId[i]] as Equip);
            Inventory.instance.equipAmount.Add(inventoryData.equipAmount[i]);
        }

        Inventory.instance.foods.Clear();
        Inventory.instance.foodAmount.Clear();
        for(int i = 0; i < inventoryData.foodsId.Count; i++)
        {
            Inventory.instance.foods.Add(Inventory.instance.allItems[inventoryData.foodsId[i]] as Food);
            Inventory.instance.foodAmount.Add(inventoryData.foodAmount[i]);
        }

        Inventory.instance.potions.Clear();
        Inventory.instance.potionAmount.Clear();
        for(int i = 0; i < inventoryData.potionsId.Count; i++)
        {
            Inventory.instance.potions.Add(Inventory.instance.allItems[inventoryData.potionsId[i]] as Potion);
            Inventory.instance.potionAmount.Add(inventoryData.potionAmount[i]);
        }

        Inventory.instance.recipes.Clear();
        for(int i = 0; i < inventoryData.recipesId.Count; i++)
        {
            Inventory.instance.recipes.Add(Inventory.instance.allItems[inventoryData.recipesId[i]] as Recipe);
        }
    }

    public void SaveData()
    {
        SetPlayerData();
        SetEventData();
        SetInventoryData();
        SaveJson();
    }

    public void LoadData()
    {
        LoadJson();
        OverlapData();
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

            if(player.equipWeapon == default)
                playerDatas[index].equipWeaponId = -1;
            else
                playerDatas[index].equipWeaponId = player.equipWeapon.itemId;

            if (player.equipArmor == default)
                playerDatas[index].equipArmorId = -1;
            else
                playerDatas[index].equipArmorId = player.equipArmor.itemId;
            
            playerDatas[index].exp = player.exp;
            playerDatas[index].level = player.level;

            index++;
        }
    }

    public void SetEventData()
    {
        eventData.isFinish = EventManager.instance.gameEvents[0].isFinish;
    }
    public void SetInventoryData()
    {
        inventoryData.nowGold = Inventory.instance.nowGold;

        for (int i = 0; i < Inventory.instance.materials.Count; i++)
        {
            inventoryData.materialsId.Add(Inventory.instance.materials[i].itemId);
        }
        inventoryData.materialAmount = Inventory.instance.materialAmount;

        for (int i = 0; i < Inventory.instance.equips.Count; i++)
        {
            inventoryData.equipsId.Add(Inventory.instance.equips[i].itemId);
        }
        inventoryData.equipAmount = Inventory.instance.equipAmount;

        for (int i = 0; i < Inventory.instance.foods.Count; i++)
        {
            inventoryData.foodsId.Add(Inventory.instance.foods[i].itemId);
        }
        inventoryData.foodAmount = Inventory.instance.foodAmount;

        for (int i = 0; i < Inventory.instance.potions.Count; i++)
        {
            inventoryData.potionsId.Add(Inventory.instance.potions[i].itemId);
        }
        inventoryData.potionAmount = Inventory.instance.potionAmount;

        for(int i = 0; i < Inventory.instance.recipes.Count; i++)
            inventoryData.recipesId.Add(Inventory.instance.recipes[i].itemId);
    }

    [Serializable]
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

        public int equipWeaponId;
        public int equipArmorId;

        public int exp;
        public int level;
    }
    [Serializable]
    public class EventData
    {
        public bool isFinish;
    }
    [Serializable]
    public class InventoryData
    {
        public int nowGold = default;

        public List<int> materialsId = new List<int>();
        public List<int> materialAmount = new List<int>();

        public List<int> equipsId = new List<int>();
        public List<int> equipAmount = new List<int>();

        public List<int> foodsId = new List<int>();
        public List<int> foodAmount = new List<int>();

        public List<int> potionsId = new List<int>();
        public List<int> potionAmount = new List<int>();

        public List<int> recipesId = new List<int>();
    }
}
