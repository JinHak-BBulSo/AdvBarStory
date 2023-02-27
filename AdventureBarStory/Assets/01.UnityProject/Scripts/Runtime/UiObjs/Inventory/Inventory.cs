using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Inventory : Singleton<Inventory>
{
    const int START_GOLD = 2000;
    public int nowGold = default;
    public TMP_Text moneyTxt = default;

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

    public override void Awake()
    {
        base.Awake();
        nowGold = START_GOLD;
        moneyTxt = GameObject.Find("InitObjs").FindChildObj("MoneyTxt").GetComponent<TMP_Text>();

        foreach(Item item in allItems)
        {
            GetItem(item);
        }
    }

    public void GetItem<T>(T _item) where T : Item
    {
        switch (_item.tag)
        {
            case "material":  
                if (!materials.Contains(_item))
                {
                    materials.Add(_item);
                    materialAmount.Add(1);
                }
                else
                {
                    materialAmount[materials.IndexOf(_item)]++;
                }
                break;
            case "equip":
                if (!equips.Contains(_item as Equip))
                {
                    equips.Add(_item as Equip);
                    equipAmount.Add(1);
                }
                else
                {
                    equipAmount[equips.IndexOf(_item as Equip)]++;
                }
                break;
            case "food":
                if (!foods.Contains(_item as Food))
                {
                    foods.Add(_item as Food);
                    foodAmount.Add(1);
                }
                else
                {
                    foodAmount[foods.IndexOf(_item as Food)]++;
                }
                break;
            case "potion":
                if (!potions.Contains(_item as Potion))
                {
                    potions.Add(_item as Potion);
                    potionAmount.Add(1);
                }
                else
                {
                    potionAmount[potions.IndexOf(_item as Potion)]++;
                }
                break;
            case "recipe":
                if(!recipes.Contains(_item as Recipe))
                {
                    recipes.Add(_item as Recipe);
                }
                else
                {
                    /* Do nothing
                     * recipe get -> only 1
                     */
                }
                break;
        }
    }

    public void UseItem<T>(T _item, int amount) where T : Item
    {
        int itemIndex = -1;
        switch (_item.tag)
        {
            case "material":
                itemIndex = materials.IndexOf(_item);
                materialAmount[itemIndex] -= amount;
                if (materialAmount[itemIndex] == 0)
                {
                    materials.RemoveAt(itemIndex);
                    materialAmount.RemoveAt(itemIndex);
                }
                break;
            case "food":
                itemIndex = foods.IndexOf(_item as Food);
                foodAmount[itemIndex] -= amount;
                if (foodAmount[itemIndex] == 0)
                {
                    foods.RemoveAt(itemIndex);
                    foodAmount.RemoveAt(itemIndex);
                }
                break;
            case "potion":
                itemIndex = potions.IndexOf(_item as Potion);
                potionAmount[itemIndex] -= amount;
                if (potionAmount[itemIndex] == 0)
                {
                    potions.RemoveAt(itemIndex);
                    potionAmount.RemoveAt(itemIndex);
                }
                break;
        }
    }

    public void SetGold(int _gold)
    {
        nowGold += _gold;
        moneyTxt.text = nowGold.ToString();
    }
}
