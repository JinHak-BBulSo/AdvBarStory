using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EatQuestionObjs : MonoBehaviour
{
    bool isSelected = false;
    GameObject foodList = default;

    private void Start()
    {
        foodList = GameObject.Find("InitObjs").FindChildObj("PopupEatObjs").FindChildObj("FoodList");
    }
    void OnDisable()
    {
        FoodSlot.nowSelectedFoodSlot = default;
    }
    public void OnClickYes()
    {
        if (!isSelected)
        {
            isSelected = true;
        }
        else
        {
            Inventory.instance.UseItem<Food>(FoodSlot.nowSelectedFoodSlot.slotItem as Food, 1);
            foodList.GetComponent<FoodList>().UpdateSlots();
            gameObject.SetActive(false);
        }
    }
    public void OnClickNo()
    {
        if (!isSelected)
        {
            isSelected = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }
}
