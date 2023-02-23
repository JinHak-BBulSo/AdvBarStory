using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject popupUI = default;
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnClickMenuBtn()
    {
        popupUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
