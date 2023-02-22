using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSlot : MonoBehaviour
{
    [SerializeField]
    GameObject slotMonster = default;
    [SerializeField]
    Monster monster = default;
    public MonsterStatus slotMonsterStatus = default;
/*    void OnEnable()
    {
        slotMonster = transform.GetChild(0).gameObject;
        monster = slotMonster.GetComponent<Monster>();
    }*/

    public void SetMonster(MonsterStatus _monster)
    {
        slotMonster = transform.GetChild(0).gameObject;
        monster = slotMonster.GetComponent<Monster>();

        monster.status._str = _monster._str;
        monster.status._vit = _monster._vit;
        monster.status._int = _monster._int;
        monster.status._men = _monster._men;
        monster.status._agi = _monster._agi;
        monster.status._hit = _monster._hit;
        monster.status._avd = _monster._avd;
        monster.status._luk = _monster._luk;

        monster.status.hp = _monster.hp;
        monster.nowHp = _monster.hp;
        monster.status.mp = _monster.mp;

        monster.gameObject.GetComponent<Image>().sprite = _monster.monsterSprite;
        monster.GetComponent<Animator>().runtimeAnimatorController = _monster.animatorController;
    }
}
