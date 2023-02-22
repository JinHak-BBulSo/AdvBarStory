using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    public List<int> itemAmountList = new List<int>();
    public List<Item> haveItems = new List<Item>();

    public List<Item> allItems = new List<Item>();
    
    public override void Awake()
    {
        base.Awake();
    }

    public void GetItem(Item _item)
    {
        if (haveItems.Contains(_item))
        {
            int idx = haveItems.IndexOf(_item);
            itemAmountList[idx]++;
        }
        else
        {          
            haveItems.Add(_item);
            itemAmountList.Add(1);
        }
    }

    public void UseItem(Item _item)
    {

    }
}
