using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public GameObject createQuestionObjs = default;
    public static Recipe recipe = default;

    private void OnDisable()
    {
        recipe = default;
    }

    public static void CreateFood()
    {
        Inventory.instance.GetItem<Food>(recipe.madeFood);
    }
}
