using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OpeningBtn : MonoBehaviour
{
    private GameObject selectBtn = default;

    void Start()
    {
        selectBtn = GFunc.GetRootObj("UiObjs").FindChildObj("OpeningSelect");

        if (EventManager.instance.gameEvents[0].isFinish) selectBtn.SetActive(false);
    }
    public void OnClickOpeningStart()
    {
        EventManager.instance.StartOpening();
        selectBtn.SetActive(false);
    }
    public void OnClickOpeningSkip()
    {
        EventManager.instance.SkipOpening();
        selectBtn?.SetActive(false);
    }
}
