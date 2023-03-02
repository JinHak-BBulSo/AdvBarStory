using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldMapBtn : MonoBehaviour, IDeselectHandler
{
    private GameObject worldMapObjs = default;
    private GameObject worldMap = default;
    private GameObject worldMapQuestionObjs = default;
    private GameObject worldMapCursor = default;
    private bool isSelected = false;

    private void Start()
    {
        worldMapObjs = GameObject.Find("InitObjs").FindChildObj("WorldMapObjs");
        worldMap = worldMapObjs.FindChildObj("WorldMap");
        worldMapQuestionObjs = worldMapObjs.FindChildObj("WorldMapQuestionObjs");
        worldMapCursor = worldMapObjs.FindChildObj("WorldMapCursor");
    }

    public void OnClickBtn()
    {
        if (isSelected)
        {
            switch (gameObject.name)
            {
                case "Town":
                    GameObject.Find("PlayerManager").FindChildObj("Player").transform.position = PlayerManager.instance.recallPlayerTownPos;
                    GameManager.instance.TownRecall();
                    GFunc.LoadScene("02.TownScene");
                    break;
                case "Stage1":
                    if (SceneManager.GetActiveScene().name != "03.Stage1Scene")
                    {
                        PlayerManager.instance.recallPlayerTownPos = GameObject.Find("PlayerManager").FindChildObj("Player").transform.position;
                        PlayerManager.instance.recallCameraPos = Camera.main.transform.position;
                    }
                    GFunc.LoadScene("03.Stage1Scene");
                    break;
                case "Stage2":
                    break;
            }

            worldMapQuestionObjs.SetActive(false);
            worldMap.SetActive(false);
        }
        else
        {
            isSelected = true;
            worldMapCursor.GetRect().anchoredPosition = gameObject.GetRect().anchoredPosition + new Vector2(0, 100);
        }
    }
    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }
}
