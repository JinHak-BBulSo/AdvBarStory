using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{
    public Vector2 initPos = default;
    [SerializeField]
    Vector2 targetPos;

    private void OnEnable()
    {
        gameObject.GetRect().anchoredPosition = initPos;
    }

    void Update()
    {
        transform.localPosition = Vector3.Slerp(gameObject.GetRect().anchoredPosition, targetPos, 0.03f);
    }
}
