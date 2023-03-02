using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Siela : Player
{
    public Sprite sielaImg = default;

    public GameObject airSlashEffect = default;
    public GameObject iceBallEffect = default;
    public GameObject burstEffect = default;

    EffectController effectController = default;

    public void BurstEdge()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            burstEffect.SetActive(true);
            effectController = burstEffect.GetComponent<EffectController>();

            int _hitDamage = (int)(status._hit * 1.6f) + (int)(status._str * 0.6);
            effectController._damage = _hitDamage;

            animator.SetBool("isAttack", true);

            weapon.SetActive(true);
            weaponAni.SetBool("isAttack", true);

            UseSkill(skillInfo[0].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(1.5f));
        }
    }
    public void AirSlash()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            airSlashEffect.SetActive(true);
            effectController = airSlashEffect.GetComponent<EffectController>();

            int _hitDamage = (int)(status._hit * 1.4f) + (int)(status._str * 0.3);
            effectController._damage = _hitDamage;

            animator.SetBool("isAttack", true);

            weapon.SetActive(true);
            weaponAni.SetBool("isAttack", true);

            UseSkill(skillInfo[1].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(1.5f));
        }
    }
    public void IceBall()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            iceBallEffect.SetActive(true);
            effectController = iceBallEffect.GetComponent<EffectController>();

            int _hitDamage = (int)(status._int * 3.0f);
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
                PlayerManager.instance.PlayerAction += BurstEdge;
                break;
            case 2:
                PlayerManager.instance.PlayerAction += AirSlash;
                break;
            case 3:
                PlayerManager.instance.PlayerAction += IceBall;
                break;
        }
    }

    public override void InitskillSet()
    {
        skillInfo.Add(("Burst Edge", 8));
        skillInfo.Add(("Air Slash", 6));
        skillInfo.Add(("Ice Ball", 6));
    }
    public override void LevelUp()
    {
        status._str += 3;
        status._vit += 2;
        status._int += 2;
        status._men += 2;
        status._hit += 5;
        status._agi += 3;
        status._avd += 1;
        status._luk += 1;

        status.hp += 15;
        status.mp += 6;
    }
}
