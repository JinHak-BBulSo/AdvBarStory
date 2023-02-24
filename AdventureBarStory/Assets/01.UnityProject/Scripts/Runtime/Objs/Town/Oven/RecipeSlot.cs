using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeSlot : Slot
{
    GameObject recipeInfoList = default;
    List<GameObject> recipeInfoObjs = new List<GameObject>();

    List<TMP_Text> recipeInfoNameTxts = new List<TMP_Text>();
    List<Image> recipeInfoImages = new List<Image>();
    List<TMP_Text> recipeInfoStockTxts = new List<TMP_Text>();
    List<Slot> infoSlots = new List<Slot>();

    public override void Start()
    {
        tooltipTxt = GameObject.Find("OvenCookObjs").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();

        recipeInfoList = GameObject.Find("OvenCookObjs").FindChildObj("RecipeInfoList");

        for (int i = 0; i < recipeInfoList.FindChildObj("ItemSlots").transform.childCount; i++)
        {
            recipeInfoObjs.Add(recipeInfoList.FindChildObj("ItemSlots").transform.GetChild(i).gameObject);
            recipeInfoNameTxts.Add(recipeInfoObjs[i].transform.GetChild(0).GetComponent<TMP_Text>());
            recipeInfoImages.Add(recipeInfoObjs[i].transform.GetChild(1).GetComponent<Image>());
            recipeInfoStockTxts.Add(recipeInfoObjs[i].transform.GetChild(2).GetComponent<TMP_Text>());

            infoSlots.Add(recipeInfoList.FindChildObj("ItemSlots").transform.GetChild(i).GetComponent<Slot>());

            recipeInfoNameTxts[i].gameObject.SetActive(false);
            recipeInfoImages[i].gameObject.SetActive(false);
            recipeInfoStockTxts[i].gameObject.SetActive(false);
        }
    }

    public override void OnClickSlot()
    {
        base.OnClickSlot();

        Recipe selectRecipe = slotItem as Recipe;
        
        for(int i = 0; i < infoSlots.Count; i++)
        {
            recipeInfoNameTxts[i].text = selectRecipe.materials[i].name;
            recipeInfoImages[i].sprite = selectRecipe.materials[i].itemImage;
            recipeInfoStockTxts[i].text = selectRecipe.requireMaterialAmount[i].ToString();
            infoSlots[i].gameObject.SetActive(true);

            if (i >= selectRecipe.materials.Count) infoSlots[i].gameObject.SetActive(false);
        }
    }
}
