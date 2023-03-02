using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour, ITurnFinishHandler
{
    public float turnRecoverySpeed = 0;
    public float turnGuage = 0;
    public bool isDie = false;
    public bool isTurnFinish = false;

    public Animator animator;

    public BattleTile onTileData = default;
    public Status status = default;

    public GameObject charImgSlot = default;

    public int nowHp;
    public int nowMp;

    public virtual void Awake()
    {
        nowHp = status.hp;
        nowMp = status.mp;
        animator = GetComponent<Animator>();
    }

    [System.Serializable]
    public struct Status
    {
        public int _str;
        public int _vit;
        public int _int;
        public int _men;
        public int _agi;
        public int _hit;
        public int _avd;
        public int _luk;

        public int hp;
        public int mp;
    }

    public void TurnRecovery()
    {
        turnRecoverySpeed = Mathf.Log10(status._agi);
        turnGuage += turnRecoverySpeed * Time.deltaTime * 5;
        charImgSlot.GetRect().anchoredPosition -= new Vector2(turnRecoverySpeed * Time.deltaTime * 5 * 38, 0);
    }

    public virtual void Attack()
    {
        /* override using */
    }

    public virtual void Hit(int damage)
    {
        int _hitDamage = damage - status._vit;

        if (_hitDamage <= 0)
        {
            nowHp -= 1;
        }
        else
        {
            nowHp -= (_hitDamage);
        }
        if (nowHp <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(HitEffect());
        }
    }

    public virtual void MagicHit(int damage)
    {
        int _hitDamage = damage - status._men;

        if (_hitDamage <= 0)
        {
            nowHp -= 1;
        }
        else
        {
            nowHp -= (_hitDamage);
        }
        if (nowHp <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(HitEffect());
        }
    }

    public void UseSkill(int consumeMp)
    {
        nowMp -= consumeMp;
    }

    public virtual void Die()
    {
        isDie = true;
        StopAllCoroutines();
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Effect") return;
        onTileData = collision.GetComponent<BattleTile>();
    }

    IEnumerator HitEffect()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    public IEnumerator TurnFinish()
    {
        yield return new WaitForSeconds(1.5f);
        charImgSlot.SetActive(true);
        turnGuage = 0;
        BattleCursor.battleTile.OnDeselect();
        onTileData.OnDeselect();
        BattleManager.instance.isTurnStart = false;
        charImgSlot.GetRect().anchoredPosition = new Vector2(244, -280);
    }
}
