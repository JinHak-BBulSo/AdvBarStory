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
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player" && nowMp > skillInfo[0].Item2)
        {
            chargeEffect.SetActive(true);
            effectController = chargeEffect.GetComponent<EffectController>();

            int _hitDamage = (int)(status._hit * 1.5f) + (int)(status._str * 0.7);
            effectController._damage = _hitDamage;

            animator.SetBool("isAttack", true);

            weapon.SetActive(true);
            weaponAni.SetBool("isAttack", true);

            UseSkill(skillInfo[0].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(1.5f));
        }
        else
        {
            PlayerManager.instance.PlayerAction -= ChargeSword;
        }
    }
    public void SwordEdge()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player" && nowMp > skillInfo[1].Item2)
        {
            swordEdgeEffect.SetActive(true);
            effectController = swordEdgeEffect.GetComponent<EffectController>();

            int _hitDamage = (int)(status._hit * 1.6f) + (int)(status._str * 0.6);
            effectController._damage = _hitDamage;

            animator.SetBool("isAttack", true);

            weapon.SetActive(true);
            weaponAni.SetBool("isAttack", true);

            UseSkill(skillInfo[1].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(1.5f));
        }
        else
        {
            PlayerManager.instance.PlayerAction -= SwordEdge;
        }
    }
    public void LastBlast()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player" && nowMp > skillInfo[2].Item2)
        {
            blastEffect.SetActive(true);
            effectController = blastEffect.GetComponent<EffectController>();

            int _hitDamage = (int)(status._int * 3.1f);
            effectController._damage = _hitDamage;

            animator.SetBool("isMagic", true);

            UseSkill(skillInfo[2].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(1.5f));
        }
        else
        {
            PlayerManager.instance.PlayerAction -= LastBlast;
        }
    }
    public override void SkillSelect(int slotIndex)
    {
        switch (slotIndex)
        {
            case 1:
                PlayerManager.instance.PlayerAction -= ChargeSword;
                PlayerManager.instance.PlayerAction += ChargeSword;
                break;
            case 2:
                PlayerManager.instance.PlayerAction -= SwordEdge;
                PlayerManager.instance.PlayerAction += SwordEdge;
                break;
            case 3:
                PlayerManager.instance.PlayerAction -= LastBlast;
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
    public override void LevelUp()
    {
        status._str += 4;
        status._vit += 3;
        status._int += 1;
        status._men += 1;
        status._hit += 4;
        status._agi += 2;
        status._avd += 1;
        status._luk += 1;

        status.hp += 18;
        status.mp += 4;
    }
}
