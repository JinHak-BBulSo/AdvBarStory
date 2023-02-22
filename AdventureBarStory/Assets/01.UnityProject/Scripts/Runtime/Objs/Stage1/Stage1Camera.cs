using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Camera : MoveCamera
{
    public bool isInField1 = true;
    public bool isInField2 = false;
    public bool isInField3 = false;

    public override void Start()
    {
        base.Start();
        player.transform.position = new Vector3(-5f, -3.5f, 0);
    }

    void Update()
    {
        OnCameraMove();
    }

    public override void OnCameraMove()
    {
        if (isInField1)
        {
            if (player.transform.position.x > 0.7f && player.transform.position.x < 12.2f)
            {
                transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
            }

            if (player.transform.position.y > 0 && player.transform.position.y < 20)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, -10);
            }
        }

        if (isInField2)
        {
            if (player.transform.position.x > 40.7f && player.transform.position.x < 52.3f)
            {
                transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
            }

            if (player.transform.position.y > 23 && player.transform.position.y < 44)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, -10);
            }
        }

        if (isInField3)
        {
            if (player.transform.position.y > 0f && player.transform.position.y < 6)
            {
                transform.position = new Vector3(40.7f, player.transform.position.y, -10);
            }
        }
    }
}
