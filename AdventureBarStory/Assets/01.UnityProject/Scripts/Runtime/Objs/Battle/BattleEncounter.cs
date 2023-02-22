using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEncounter : MonoBehaviour
{
    private float collisionDetectionDelay = 1f;
    private bool isCollisionAble = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isCollisionAble)
        {
            isCollisionAble = false;
            StartCoroutine(ResetCollisionDelay());

            Debug.Log("호출되나 확인");
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
}
