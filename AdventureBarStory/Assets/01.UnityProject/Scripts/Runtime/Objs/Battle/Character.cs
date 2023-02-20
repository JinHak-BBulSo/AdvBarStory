using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float turnRecoverySpeed = 0;

    public Status status = default;
    public BattleCursor battleCursor = default;

    void Start()
    {
        battleCursor = GameObject.Find("BattleObjs").FindChildObj("BattleCursor").GetComponent<BattleCursor>();
    }

    public struct Status
    {
        public int _str;
        public int _vit;
        public int _int;
        public int _men;
        public int _agi;
        public int _luk;

        public int hp;
        public int mp;
    }

    public virtual void StatusSet()
    {

    }

    public void TurnRecovery()
    {
        turnRecoverySpeed = Mathf.Log10(status._agi);
    }

    public void Attack()
    {

    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
