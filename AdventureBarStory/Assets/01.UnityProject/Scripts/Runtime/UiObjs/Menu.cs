using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject itemUI = default;
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnClickMenuBtn()
    {
        itemUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
