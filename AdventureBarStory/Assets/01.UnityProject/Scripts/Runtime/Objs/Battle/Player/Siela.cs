using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Siela : Player
{
    public Sprite sielaImg = default;
    public GameObject airSlashEffect = default;

    void Start()
    {
        skillInfo.Add(("Burst Edge", 8));
        skillInfo.Add(("Air Slash", 6));
        skillInfo.Add(("Ice Ball", 6));
    }   

    public void BurstEdge()
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
    public void AirSlash()
    {
        if (BattleCursor.battleTile.onTileObject != default && BattleCursor.battleTile.onTileObject.tag != "Player")
        {
            airSlashEffect.SetActive(true);
            
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
            int _hitDamage = (int)(status._hit * 1.45f);
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
}
