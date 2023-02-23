using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEncounter : MonoBehaviour
{
    private float collisionDetectionDelay = 0.7f;
    private bool isCollisionAble = true;

    void Start()
    {
        StartCoroutine(StartEncounterDelay());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isCollisionAble &&
            BattleManager.instance.isBattleAble)
        {
            isCollisionAble = false;
            StartCoroutine(ResetCollisionDelay());

            int ran = Random.Range(0, 100 + 1);

            if (ran <= 15 && !BattleManager.instance.isBattleStart)
            {
                BattleManager.instance.BattleStart();
            }
            else
            {
                /* Do nothing */
            }
        }
    }

    IEnumerator ResetCollisionDelay()
    {
        yield return new WaitForSeconds(collisionDetectionDelay);
        isCollisionAble = true;
    }

    IEnumerator StartEncounterDelay()
    {
        isCollisionAble = false;
        yield return new WaitForSeconds(3f);
        isCollisionAble = true;
    }
}
