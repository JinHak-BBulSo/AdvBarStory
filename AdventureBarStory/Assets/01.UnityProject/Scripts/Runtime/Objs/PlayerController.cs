using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAni = default;
    private Rigidbody2D playerRigid = default;

    private float speed = 5f;

    void Start()
    {
        playerAni = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateState();
    }

    void UpdateState()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerAni.SetInteger("Dir", 1);
            playerAni.SetBool("isMove", true);
            playerRigid.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            playerAni.SetInteger("Dir", 2);
            playerAni.SetBool("isMove", true);
            playerRigid.velocity = Vector2.down * speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAni.SetInteger("Dir", 0);
            playerAni.SetBool("isMove", true);
            playerRigid.velocity = Vector2.right * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAni.SetInteger("Dir", 0);
            playerAni.SetBool("isMove", true);
            playerRigid.velocity = Vector2.left * speed;
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow) ||
            Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.RightArrow) ||
            Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerAni.SetBool("isMove", false);
            playerRigid.velocity = Vector2.zero;
        }
    }
}
