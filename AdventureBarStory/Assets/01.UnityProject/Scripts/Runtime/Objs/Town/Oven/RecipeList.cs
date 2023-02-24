using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeList : SlotList
{
    void OnEnable()
    {
        SlotSet<Recipe>(Inventory.instance.recipes, "recipe");
    }
}
