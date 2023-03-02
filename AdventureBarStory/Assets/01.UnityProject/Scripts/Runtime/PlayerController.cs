using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAni = default;
    private Rigidbody2D playerRigid = default;

    private float speed = 5f;

    public bool isLeft = false;
    public bool isRight = false;
    public bool isUp = false;
    public bool isDown = false;

    void Awake()
    {
        playerAni = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateState();
    }

    private void OnDisable()
    {
        playerRigid.velocity = Vector3.zero;
        playerAni.SetBool("isMove", false);
    }

    void UpdateState()
    {
        if (Input.GetKey(KeyCode.UpArrow) || isUp)
        {
            playerAni.SetInteger("Dir", 1);
            playerAni.SetBool("isMove", true);
            playerRigid.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || isDown)
        {
            playerAni.SetInteger("Dir", 2);
            playerAni.SetBool("isMove", true);
            playerRigid.velocity = Vector2.down * speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || isRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAni.SetInteger("Dir", 0);
            playerAni.SetBool("isMove", true);
            playerRigid.velocity = Vector2.right * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || isLeft)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAni.SetInteger("Dir", 0);
            playerAni.SetBool("isMove", true);
            playerRigid.velocity = Vector2.left * speed;
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow) ||
            Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.RightArrow) ||
            Input.GetKeyUp(KeyCode.LeftArrow) ||
            (!isLeft && !isRight && !isUp && !isDown))
        {
            playerAni.SetBool("isMove", false);
            playerRigid.velocity = Vector2.zero;
        }
    }
}
