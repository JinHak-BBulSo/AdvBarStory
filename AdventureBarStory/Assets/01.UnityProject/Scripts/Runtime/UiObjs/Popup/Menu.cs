using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject popupUI = default;
    [SerializeField]
    GameObject back = default;

    public void OnClickMenuBtn()
    {
        popupUI.SetActive(true);
        back.SetActive(true);
        gameObject.SetActive(false);
    }
}
