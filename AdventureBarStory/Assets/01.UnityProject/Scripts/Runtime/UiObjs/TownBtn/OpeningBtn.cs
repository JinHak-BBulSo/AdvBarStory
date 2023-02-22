using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OpeningBtn : MonoBehaviour
{
    private GameObject selectBtn = default;
    private GameObject player = default;

    void Start()
    {
        selectBtn = GFunc.GetRootObj("UiObjs").FindChildObj("OpeningSelect");
        player = GameObject.Find("PlayerManager").FindChildObj("Player");

        player.GetComponent<PlayerController>().enabled = false;

        if (EventManager.instance.gameEvents[0].isFinish) selectBtn.SetActive(false);
    }
    public void OnClickOpeningStart()
    {
        EventManager.instance.StartOpening();
        selectBtn.SetActive(false);
    }
    public void OnClickOpeningSkip()
    {
        player.GetComponent<PlayerController>().enabled = true;
        EventManager.instance.SkipOpening();
        selectBtn?.SetActive(false);
    }
}
