using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OpeningBtn : MonoBehaviour
{
    private GameObject selectBtn = default;

    void Start()
    {
        selectBtn = GameObject.Find("OpeningStartBtn");
    }
    public void OnClickOpeningStart()
    {
        EventManager.instance.StartOpening();
    }
    public void OnClickOpeningSkip()
    {
        EventManager.instance.SkipOpening();
    }
}
