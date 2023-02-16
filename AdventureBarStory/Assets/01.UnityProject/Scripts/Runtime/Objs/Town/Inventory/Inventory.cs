using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory instance = default;
    public List<(Item, int)> itemList = new List<(Item, int)>();
    public List<Item> haveItems = new List<Item>();
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GetItem(Item _item)
    {
        if (haveItems.Contains(_item))
        {
            int idx = haveItems.IndexOf(_item);
            itemList[idx] = (_item, itemList[idx].Item2 + 1);
            Debug.Log(itemList[idx].Item2);
        }
        else
        {          
            haveItems.Add(_item);
            itemList.Add((_item, 1));
            Debug.Log(itemList[haveItems.IndexOf(_item)].Item2);
        }
    }

    public void UseItem(Item _item)
    {

    }
}
