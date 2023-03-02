using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    int speed = 360;
    bool isRotated = true;

    void Update()
    {
        if(isRotated)
            transform.rotation *= Quaternion.Euler(0, 0, speed * Time.deltaTime);
        else
        {
            return;
        }
    }

    private void OnEnable()
    {
        isRotated = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
            isRotated = false;
    }
}
