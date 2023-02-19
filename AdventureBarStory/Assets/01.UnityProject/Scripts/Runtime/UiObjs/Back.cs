using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour, IBackBtnHandler
{
    [SerializeField]
    GameObject menu = default;
    [SerializeField]
    GameObject itemUi = default;

    public void OnBackBtnClick()
    {
        throw new System.NotImplementedException();
    }

    public void OnClickBackBtn()
    {
        menu.SetActive(true);
        itemUi.SetActive(false);
    }
}
