using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alfine : Player
{
    public Sprite sielaImg = default;
    void Start()
    {
        skillInfo.Add(("Fire Ball", 8));
        skillInfo.Add(("Flame Rage", 6));
        skillInfo.Add(("Heal", 6));
    }

    public void FireBall()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            int _hitDamage = (int)(status._hit * 1.6f);
            BattleCursor.battleTile.onTileObject.GetComponent<Character>().Hit(_hitDamage);
            animator.SetBool("isAttack", true);

            weapon.SetActive(true);
            weaponAni.SetBool("isAttack", true);

            UseSkill(skillInfo[0].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(0.8f));
        }
    }
    public void FlameRage()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            int _hitDamage = (int)(status._hit * 1.6f);
            BattleCursor.battleTile.onTileObject.GetComponent<Character>().Hit(_hitDamage);
            animator.SetBool("isAttack", true);

            weapon.SetActive(true);
            weaponAni.SetBool("isAttack", true);

            UseSkill(skillInfo[1].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(0.8f));
        }
    }
    public void Heal()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag == "Player")
        {
            int _heal = (int)(status._int * 0.7f);
            Player healTarget = BattleCursor.battleTile.onTileObject.GetComponent<Character>() as Player;

            healTarget.Recovery(_heal, 0);
            animator.SetBool("isAttack", true);

            weapon.SetActive(true);
            weaponAni.SetBool("isAttack", true);

            UseSkill(skillInfo[2].Item2);
            charSlot.UpdateText();
            StartCoroutine(TurnFinish(0.8f));
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
                PlayerManager.instance.PlayerAction += FlameRage;
                break;
            case 3:
                PlayerManager.instance.PlayerAction += Heal;
                break;
        }
    }
}
