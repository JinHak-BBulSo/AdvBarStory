using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using JetBrains.Annotations;

[System.Serializable]
[CreateAssetMenu(menuName = "Item", order = 0)]
public class Item : ScriptableObject
{
    public string itemName;
    public string tag;
    public string toolTip;
    public Sprite itemImage;
}
