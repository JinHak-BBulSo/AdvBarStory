using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Potion", order = 0)]
public class Potion : Item
{
    public int recoveryHp;
    public int recoveryMp;
}
