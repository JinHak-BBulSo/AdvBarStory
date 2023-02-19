using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapPortal : MonoBehaviour
{
    private GameObject worldMapObjs = default;
    private GameObject worldMapQuestion = default;
    void Start()
    {
        worldMapObjs = GameObject.Find("InitObjs").FindChildObj("WorldMapObjs");
        worldMapQuestion = worldMapObjs.FindChildObj("WorldMapQuestionObjs");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            worldMapQuestion.SetActive(true);
        }
    }
}
