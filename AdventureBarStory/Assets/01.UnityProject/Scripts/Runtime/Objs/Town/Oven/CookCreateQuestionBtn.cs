using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookCreateQuestionBtn : MonoBehaviour
{
    GameObject cookCreateQuestionObjs = default;

    void Awake()
    {
        cookCreateQuestionObjs = gameObject;    
    }
    public void OnClickYes()
    {
        Oven.CreateFood();
        cookCreateQuestionObjs.SetActive(false);
    }
    public void OnClickNo()
    {
        cookCreateQuestionObjs.SetActive(false);
    }
}
