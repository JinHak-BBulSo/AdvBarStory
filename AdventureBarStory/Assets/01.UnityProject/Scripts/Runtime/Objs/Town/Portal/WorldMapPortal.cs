using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapPortal : MonoBehaviour
{
    public static float worldMoveDelay = 0.3f;
    public static bool isMoveAble = true;
    private GameObject worldMapObjs = default;
    private GameObject worldMapQuestion = default;
    void Start()
    {
        worldMapObjs = GameObject.Find("InitObjs").FindChildObj("WorldMapObjs");
        worldMapQuestion = worldMapObjs.FindChildObj("WorldMapQuestionObjs");
        StartCoroutine(WorldMapDelay());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && isMoveAble)
        {
            worldMapQuestion.SetActive(true);
        }
    }

    public static IEnumerator WorldMapDelay()
    {
        isMoveAble = false;
        yield return new WaitForSeconds(worldMoveDelay);
        isMoveAble = true;
    }
}
