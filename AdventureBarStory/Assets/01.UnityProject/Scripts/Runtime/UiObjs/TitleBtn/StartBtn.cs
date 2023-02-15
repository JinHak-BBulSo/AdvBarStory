using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    public void OnClickStartBtn()
    {
        GFunc.LoadScene("02.TownScene");
    }
}
