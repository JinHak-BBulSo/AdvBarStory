using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class MonsterStatus : ScriptableObject
{
    public AnimatorController animatorController;
    public Sprite monsterSprite;

    public int _str;
    public int _vit;
    public int _int;
    public int _men;
    public int _agi;
    public int _hit;
    public int _avd;
    public int _luk;

    public int hp;
    public int mp;
}
