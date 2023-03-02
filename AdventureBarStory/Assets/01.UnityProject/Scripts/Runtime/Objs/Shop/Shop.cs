using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour, IBackBtnHandler
{
    public static Shop instance = default;
    GameObject money = default;

    public List<Item> shopMaterials = new List<Item>();
    public List<Equip> shopEquips = new List<Equip>();
    public List<Potion> shopPotions = new List<Potion>();
    public List<Recipe> shopRecipes = new List<Recipe>();

    GameObject backBtn = default;
    void Awake()
    {
        backBtn = GameObject.Find("InitObjs").FindChildObj("Back");
        money = GameObject.Find("InitObjs").FindChildObj("Money");
        // not Singleton. 호출을 용이하게 하기 위한 instance
        instance = this;
    }

    void OnEnable()
    {
        backBtn.SetActive(true);
        money.SetActive(true);
        PlayerMoveBtns.instance.gameObject.SetActive(false);

        Back.clickBackBtn += OnBackBtnClick;
    }
    void OnDisable()
    {
        backBtn.SetActive(false);
        money.SetActive(false);

        Back.clickBackBtn -= OnBackBtnClick;
    }

    public void OnBackBtnClick()
    {
        PlayerMoveBtns.instance.gameObject.SetActive(true);
        gameObject.SetActive(false);
        gameObject.FindChildObj("TooltipTxt").GetComponent<TMP_Text>().text = string.Empty;
        PlayerManager.instance.player.GetComponent<PlayerController>().enabled = true;
    }
}
