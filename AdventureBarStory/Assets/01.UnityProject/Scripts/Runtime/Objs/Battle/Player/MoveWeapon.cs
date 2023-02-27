using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWeapon : MonoBehaviour
{
    Rigidbody2D weaponRigid = default;
    void Start()
    {
        weaponRigid = GetComponent<Rigidbody2D>();

        weaponRigid.velocity = new Vector2(-1, -1).normalized * 50;
    }

    public void SetSwordPos()
    {
        gameObject.GetRect().anchoredPosition = new Vector2(39, 34);
    }
}
