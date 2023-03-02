using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int exp = 0;
    public int level = 1;

    public AudioSource audioSource = default;

    public GameObject weapon = default;
    public Animator weaponAni = default;

    [SerializeField]
    protected BattleSimpleCharSlot charSlot = default;

    public List<(string, int)> skillInfo = new List<(string, int)>();
    public List<string> skillTooltip = new List<string>();

    public Equip equipWeapon = default;
    public Equip equipArmor = default;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void Attack()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            BattleCursor.battleTile.onTileObject.GetComponent<Character>().Hit(status._hit);
            animator.SetBool("isAttack", true);

            weapon.SetActive(true);
            weaponAni.SetBool("isAttack", true);
            
            audioSource.Play();
            StartCoroutine(TurnFinish(0.8f));
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
        charImgSlot.SetActive(true);

        turnGuage = 0;
        BattleCursor.battleTile.OnDeselect();
        onTileData.OnDeselect();
        BattleManager.instance.isTurnStart = false;
        charImgSlot.GetRect().anchoredPosition = new Vector2(244, -324);

        weaponAni.SetBool("isAttack", false);
        animator.SetBool("isAttack", false);
        animator.SetBool("isMagic", false);
        weapon.SetActive(false);
    }
    public override void Hit(int damage)
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

        audioSource.Play();
        animator.SetBool("isHit", true);
        charSlot.UpdateText();
        StartCoroutine(HitMotion());
    }

    public void Recovery(int _hp, int _mp)
    {
        nowHp += _hp;
        if (nowHp > status.hp)
            nowHp = status.hp;


        nowMp += _mp;
        if (nowMp > status.mp)
            nowMp = status.mp;

        charSlot.UpdateText();
    }
    public override void Die()
    {
        base.Die();
        charSlot.gameObject.SetActive(false);
        weapon.SetActive(false);
        charImgSlot.SetActive(false);
        charImgSlot.GetRect().anchoredPosition = new Vector2(244, -324);
    }

    public IEnumerator HitMotion()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isHit", false);
    }
    public virtual void SkillSelect(int slotIndex)
    {
        /* Player Character each override */
    }
    public virtual void InitskillSet()
    {
        /* Player Character each override */
    }
    public virtual void LevelUp()
    {
        /* Player Character each override */
    }
}
