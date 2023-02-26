using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecipeSlot : Slot, IDeselectHandler
{
    GameObject recipeInfoList = default;
    List<GameObject> recipeInfoObjs = new List<GameObject>();
    Button button = default;

    List<TMP_Text> recipeInfoNameTxts = new List<TMP_Text>();
    List<Image> recipeInfoImages = new List<Image>();
    List<TMP_Text> recipeInfoStockTxts = new List<TMP_Text>();
    List<Slot> infoSlots = new List<Slot>();

    public GameObject createQuestionObjs = default;
    public Recipe selectRecipe = default;
    private bool isSelected = false;

    private bool createAble = true;

    public override void Awake()
    {
        tooltipTxt = GameObject.Find("OvenCookObjs").FindChildObj("TooltipTxt").GetComponent<TMP_Text>();
        recipeInfoList = GameObject.Find("OvenCookObjs").FindChildObj("RecipeInfoList");
        createQuestionObjs = GameObject.Find("OvenCookObjs").FindChildObj("CookCreateQustionObjs");
        button = GetComponent<Button>();

        for (int i = 0; i < recipeInfoList.FindChildObj("ItemSlots").transform.childCount; i++)
        {
            recipeInfoObjs.Add(recipeInfoList.FindChildObj("ItemSlots").transform.GetChild(i).gameObject);
            recipeInfoNameTxts.Add(recipeInfoObjs[i].transform.GetChild(0).GetComponent<TMP_Text>());
            recipeInfoImages.Add(recipeInfoObjs[i].transform.GetChild(1).GetComponent<Image>());
            recipeInfoStockTxts.Add(recipeInfoObjs[i].transform.GetChild(2).GetComponent<TMP_Text>());

            infoSlots.Add(recipeInfoList.FindChildObj("ItemSlots").transform.GetChild(i).GetComponent<Slot>());
            infoSlots[i].gameObject.SetActive(false);
        }
    }

    public override void OnClickSlot()
    {
        selectRecipe = slotItem as Recipe;

        if (!isSelected)
        {
            base.OnClickSlot();
            isSelected = true;

            for (int i = 0; i < infoSlots.Count; i++)
            {
                if (i >= selectRecipe.materials.Count)
                {
                    infoSlots[i].gameObject.SetActive(false);
                    return;
                }

                recipeInfoNameTxts[i].text = selectRecipe.materials[i].name;
                recipeInfoImages[i].sprite = selectRecipe.materials[i].itemImage;
                recipeInfoStockTxts[i].text = selectRecipe.requireMaterialAmount[i].ToString();
                infoSlots[i].gameObject.SetActive(true);
            }

            if (createAble)
            {
                tooltipTxt.text += selectRecipe.toolTip + " 제작가능";
            }
            else
            {
                tooltipTxt.text += selectRecipe.toolTip + " 제작불가";
            }
        }
        else if (isSelected)
        {
            if (createAble)
            {
                Oven.recipe = selectRecipe;
                createQuestionObjs.SetActive(true);
            }
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }

    public void RecipeCreateCheck()
    {
        selectRecipe = slotItem as Recipe;

        for(int i = 0; i < selectRecipe.materials.Count; i++)
        {
            Item material = selectRecipe.materials[i];
            int materialIndex = Inventory.instance.materials.IndexOf(material);
            if (Inventory.instance.materials.Contains(material))
            {
                if(Inventory.instance.materialAmount[materialIndex] >= selectRecipe.requireMaterialAmount[i])
                {
                    continue;
                }
                else
                {
                    createAble = false;
                    transform.GetChild(0).GetComponent<TMP_Text>().color = Color.red;
                    break;
                }
            }
            else
            {
                createAble = false;
                transform.GetChild(0).GetComponent<TMP_Text>().color = Color.red;
                break;
            }
        }
    }
}
