using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadQuestionBtns : MonoBehaviour, IDeselectHandler
{
    bool isSelected = false;
    GameObject popupLoadObjs = default;

    void Awake()
    {
        popupLoadObjs = GameObject.Find("InitObjs").FindChildObj("PopupLoadObjs");
    }
    public void OnClickYes()
    {
        if (!isSelected)
        {
            isSelected = true;
        }
        else
        {
            DataManager.instance.LoadData();
            PlayerManager.instance.player.transform.position = new Vector3(-0.5f, -3f, 0);
            PlayerMoveBtns.instance.gameObject.SetActive(false);
            GameObject.Find("InitObjs").FindChildObj("PopupUi").SetActive(false);

            SceneManager.LoadScene("02.TownScene");
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
            popupLoadObjs.SetActive(false);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }
}
