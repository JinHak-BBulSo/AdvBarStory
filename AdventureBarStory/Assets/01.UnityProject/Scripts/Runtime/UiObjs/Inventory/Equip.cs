using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Equip", order = 0)]
public class Equip : Item
{
    public int _atk;
    public int _def;
    public int _int;
    public string equipTag;
}
