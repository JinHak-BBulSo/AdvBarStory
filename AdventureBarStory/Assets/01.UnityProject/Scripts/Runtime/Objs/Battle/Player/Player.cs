using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int exp = 0;
    public int level = 1;
    AudioSource audioSource = default;

    public GameObject weapon = default;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void Attack()
    {
        if (BattleCursor.battleTile.onTileObject != default)
        {
            BattleCursor.battleTile.onTileObject.GetComponent<Character>().Hit(status._hit);
            animator.SetBool("isAttack", true);
            weapon.SetActive(true);
            StartCoroutine(TurnFinish(1.2f));
        }
    }

    public void RecallRecovery()
    {
        nowHp = status.hp;
        nowMp = status.mp;
        turnGuage = 0;
        isDie = false;
        isTurnFinish = false;
    }

    public IEnumerator TurnFinish(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        turnGuage = 0;
        weapon.SetActive(false);
        BattleCursor.battleTile.OnDeselect();
        onTileData.OnDeselect();
        BattleManager.instance.isTurnStart = false;

        animator.SetBool("isAttack", false);
    }
}
