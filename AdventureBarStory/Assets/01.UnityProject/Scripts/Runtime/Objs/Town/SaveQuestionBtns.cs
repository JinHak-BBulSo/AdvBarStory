using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SaveQuestionBtns : MonoBehaviour
{
    bool isSelected = false;
    public void OnClickYes()
    {
        if (!isSelected)
        {
            isSelected = true;
        }
        else
        {
            DataManager.instance.SaveData();
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
