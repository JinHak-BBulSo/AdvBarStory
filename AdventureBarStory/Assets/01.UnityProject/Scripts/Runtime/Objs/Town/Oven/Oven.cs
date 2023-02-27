using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public GameObject createQuestionObjs = default;
    public static Recipe recipe = default;
    public static RecipeSlot recipeSlot = default;
    public static RecipeList recipeList = default;

    private void OnDisable()
    {
        recipe = default;
    }

    public static void CreateFood()
    {
        // 재료 사용
        for (int i = 0; i < recipe.materials.Count; i++)
        {
            Item material = recipe.materials[i];
            int materialAmount = recipe.requireMaterialAmount[i];

            Inventory.instance.UseItem<Item>(material, materialAmount);
        }

        recipeList.SlotRecipeCreateCheck();
        Inventory.instance.GetItem<Food>(recipe.madeFood);
    }
}
