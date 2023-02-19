using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldQuestionMapBtn : MonoBehaviour
{
    private GameObject worldMapObjs = default;
    private GameObject worldMap = default;

    private void Start()
    {
        worldMapObjs = GameObject.Find("InitObjs").FindChildObj("WorldMapObjs");
        worldMap = worldMapObjs.FindChildObj("WorldMap");
    }
    public void OnClickYesBtn()
    {
        worldMap.SetActive(true);
    }

    public void OnClickNoBtn()
    {
        gameObject.SetActive(false);
    }
}
