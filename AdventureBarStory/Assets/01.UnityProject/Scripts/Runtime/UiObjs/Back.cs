using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField]
    GameObject menu = default;
    [SerializeField]
    GameObject itemUi = default;

    public void OnClickBackBtn()
    {
        menu.SetActive(true);
        itemUi.SetActive(false);
    }
}
