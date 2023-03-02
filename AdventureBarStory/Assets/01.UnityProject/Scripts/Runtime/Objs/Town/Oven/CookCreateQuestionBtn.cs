using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookCreateQuestionBtn : MonoBehaviour
{
    GameObject cookCreateQuestionObjs = default;

    GameObject foodGetTxtObjs = default;
    TMP_Text foodGetTxt = default;
    Image foodImage = default;

    void Awake()
    {
        cookCreateQuestionObjs = gameObject;

        foodGetTxtObjs = GameObject.Find("InitObjs").FindChildObj("FoodGetTxtObjs");
        foodGetTxt = foodGetTxtObjs.FindChildObj("FoodGetTxt").GetComponent<TMP_Text>();
        foodImage = foodGetTxtObjs.FindChildObj("FoodImage").GetComponent<Image>();
    }
    public void OnClickYes()
    {
        Oven.CreateFood();
        OnFoodGetTxt();
        cookCreateQuestionObjs.SetActive(false);
    }
    public void OnClickNo()
    {
        cookCreateQuestionObjs.SetActive(false);
    }
    void OnFoodGetTxt()
    {
        foodGetTxtObjs.SetActive(true);
        foodImage.sprite = Oven.recipe.madeFood.itemImage;
        foodGetTxt.text = string.Format("      {0} Get\nAdd Inventory", Oven.recipe.madeFood.name);
    }
}
