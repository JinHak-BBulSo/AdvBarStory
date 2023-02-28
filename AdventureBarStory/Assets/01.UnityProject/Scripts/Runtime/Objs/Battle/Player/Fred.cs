using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fred : Player
{
    public GameObject airSlash = default;
    public Sprite sielaImg = default;
    void Start()
    {
        skillInfo.Add(("Charge Sword", 8));
        skillInfo.Add(("Ice Sword", 6));
        skillInfo.Add(("Last Blast", 6));
    }
    public void ChargeSword()
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
    public void IceSword()
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
    public void LastBlast()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            int _hitDamage = (int)(status._hit * 1.6f);
            BattleCursor.battleTile.onTileObject.GetComponent<Character>().Hit(_hitDamage);
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
                PlayerManager.instance.PlayerAction += ChargeSword;
                break;
            case 2:
                PlayerManager.instance.PlayerAction += IceSword;
                break;
            case 3:
                PlayerManager.instance.PlayerAction += LastBlast;
                break;
        }
    }

}
