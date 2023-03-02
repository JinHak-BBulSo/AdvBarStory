using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Food", order = 0)]
public class Food : Item
{
    public int getExpAmount;
    public int getSatiety;
}
