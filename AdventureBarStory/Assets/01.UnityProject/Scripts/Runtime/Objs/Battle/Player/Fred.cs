using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fred : Player
{
    public Sprite sielaImg = default;

    public GameObject chargeEffect = default;
    public GameObject swordEdgeEffect = default;
    public GameObject blastEffect = default;

    EffectController effectController = default;
    public void ChargeSword()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            chargeEffect.SetActive(true);
            effectController = chargeEffect.GetComponent<EffectController>();

            int _hitDamage = (int)(status._hit * 1.5f);
            effectController._damage = _hitDamage;

            animator.SetBool("isAttack", true);

            weapon.SetActive(true);
            weaponAni.SetBool("isAttack", true);

            UseSkill(skillInfo[0].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(1.5f));
        }
    }
    public void SwordEdge()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            swordEdgeEffect.SetActive(true);
            effectController = chargeEffect.GetComponent<EffectController>();

            int _hitDamage = (int)(status._hit * 1.6f);
            effectController._damage = _hitDamage;

            animator.SetBool("isAttack", true);

            weapon.SetActive(true);
            weaponAni.SetBool("isAttack", true);

            UseSkill(skillInfo[1].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(1.5f));
        }
    }
    public void LastBlast()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            blastEffect.SetActive(true);
            effectController = chargeEffect.GetComponent<EffectController>();

            int _hitDamage = (int)(status._int * 1.5f);
            effectController._damage = _hitDamage;

            animator.SetBool("isMagic", true);

            UseSkill(skillInfo[2].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(1.5f));
        }
    }
    public override void SkillSelect(int slotIndex)
    {
        switch (slotIndex)
        {
            case 1:
                PlayerManager.instance.PlayerAction += ChargeSword;
                break;
            case 2:
                PlayerManager.instance.PlayerAction += SwordEdge;
                break;
            case 3:
                PlayerManager.instance.PlayerAction += LastBlast;
                break;
        }
    }
    public override void InitskillSet()
    {
        skillInfo.Add(("Charge Sword", 8));
        skillInfo.Add(("Sword Edge", 6));
        skillInfo.Add(("Last Blast", 6));
    }
}
