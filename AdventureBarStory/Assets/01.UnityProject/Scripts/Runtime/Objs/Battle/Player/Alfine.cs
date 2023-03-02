using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alfine : Player
{
    public Sprite sielaImg = default;

    public GameObject fireBallEffect = default;
    public GameObject flashLightEffect = default;
    public GameObject healEffect = default;

    EffectController effectController = default;

    public void FireBall()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            fireBallEffect.SetActive(true);
            effectController = fireBallEffect.GetComponent<EffectController>();

            int _hitDamage = (int)(status._int * 3.2f);
            effectController._damage = _hitDamage;

            animator.SetBool("isMagic", true);

            UseSkill(skillInfo[0].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(1.5f));
        }
    }
    public void FlashLight()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            flashLightEffect.SetActive(true);
            effectController = flashLightEffect.GetComponent<EffectController>();

            int _hitDamage = (int)(status._int * 2.7f);
            effectController._damage = _hitDamage;

            animator.SetBool("isMagic", true);

            UseSkill(skillInfo[1].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(1.5f));
        }
    }
    public void Heal()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag == "Player")
        {
            healEffect.SetActive(true);
            int _heal = (int)(status._int * 0.7f);
            Player healTarget = BattleCursor.battleTile.onTileObject.GetComponent<Character>() as Player;

            healTarget.Recovery(_heal, 0);
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
                PlayerManager.instance.PlayerAction += FireBall;
                break;
            case 2:
                PlayerManager.instance.PlayerAction += FlashLight;
                break;
            case 3:
                PlayerManager.instance.PlayerAction += Heal;
                break;
        }
    }
    public override void InitskillSet()
    {
        skillInfo.Add(("Fire Ball", 8));
        skillInfo.Add(("Flash Light", 6));
        skillInfo.Add(("Heal", 6));
    }
    public override void LevelUp()
    {
        status._str += 1;
        status._vit += 1;
        status._int += 5;
        status._men += 4;
        status._hit += 3;
        status._agi += 2;
        status._avd += 1;
        status._luk += 1;

        status.hp += 9;
        status.mp += 9;
    }
}
