using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Recipe", order = 0)]
public class Recipe : ScriptableObject
{
    public List<Item> materials = new List<Item>();
    public List<int> requireMaterialAmount = new List<int>();
}
