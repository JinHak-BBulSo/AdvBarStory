using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveBtns : MonoBehaviour
{
    public static PlayerMoveBtns instance;
    GameObject initObjs = default;
    PlayerController playerController = default;
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }
}
