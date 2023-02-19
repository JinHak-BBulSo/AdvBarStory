using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Portal : MonoBehaviour
{
    GameObject player = default;
    void Start()
    {
        player = GameObject.Find("PlayerManager").FindChildObj("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 destination = default;
            Vector3 cameraPos = default;

            switch (gameObject.name)
            {
                case "Stage1Field1ToField2Portal":
                    Camera.main.GetComponent<Stage1Camera>().isInField1 = false;
                    Camera.main.GetComponent<Stage1Camera>().isInField2 = true;
                    destination = new Vector2(56.5f, 19.5f);
                    cameraPos = new Vector3(52.3f, 23, -10);
                    break;
                case "Stage1Field2ToField1Portal":
                    Camera.main.GetComponent<Stage1Camera>().isInField2 = false;
                    Camera.main.GetComponent<Stage1Camera>().isInField1 = true;
                    destination = new Vector2(16.5f, 24.5f);
                    cameraPos = new Vector3(12.2f, 20f, -10);
                    break;
                case "Stage1Field1ToField3Portal":
                    Camera.main.GetComponent<Stage1Camera>().isInField1 = false;
                    Camera.main.GetComponent<Stage1Camera>().isInField3 = true;
                    destination = new Vector2(30.8f, 7.1f);
                    cameraPos = new Vector3(40.7f, 6, -10);
                    break;
                case "Stage1Field3ToField1Portal":
                    Camera.main.GetComponent<Stage1Camera>().isInField3 = false;
                    Camera.main.GetComponent<Stage1Camera>().isInField1 = true;
                    destination = new Vector2(22.4f, 5.1f);
                    cameraPos = new Vector3(12.2f, 5f, -10);
                    break;
                case "Stage1Field3ToField1HiddenRoomPortal":
                    Camera.main.GetComponent<Stage1Camera>().isInField3 = false;
                    Camera.main.GetComponent<Stage1Camera>().isInField1 = true;
                    destination = new Vector2(22.3f, -0.8f);
                    cameraPos = new Vector3(12.2f, 0f, -10);
                    break;
                case "Stage1Field1HiddenRoomToField3Portal":
                    Camera.main.GetComponent<Stage1Camera>().isInField1 = false;
                    Camera.main.GetComponent<Stage1Camera>().isInField3 = true;
                    destination = new Vector2(30.5f, -1f);
                    cameraPos = new Vector3(40.7f, 0f, -10);
                    break;
            }

            player.transform.position = destination;
            Camera.main.transform.position = cameraPos;
        }
    }
}
