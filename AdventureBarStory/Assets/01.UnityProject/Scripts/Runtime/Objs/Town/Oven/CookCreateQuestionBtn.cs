using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookCreateQuestionBtn : MonoBehaviour
{
    GameObject cookCreateQuestionObjs = default;

    void Awake()
    {
        cookCreateQuestionObjs = transform.parent.gameObject;    
    }
    public void OnClickYes()
    {
        Oven.CreateFood();
    }
    public void OnClickNo()
    {
        cookCreateQuestionObjs.SetActive(false);
    }
}
