using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : Singleton<Popup>
{
    GameObject itemUI = default;
    public override void Awake()
    {
        base.Awake();
        itemUI = gameObject.FindChildObj("ItemUi");
        itemUI.SetActive(false);
    }
}
