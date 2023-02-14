using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    GameObject player = default;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 destination = default;
            Vector3 cameraPos = default;

            switch (gameObject.name)
            {
                case "BarToStreetPortal":
                    Camera.main.GetComponent<TownCamera>().isInBar = false;
                    Camera.main.GetComponent<TownCamera>().isInStreet = true;
                    destination = new Vector2(-42.5f, -2f);
                    cameraPos = new Vector3(0, -8f, -10);
                    break;
                case "StreetToBarPortal":
                    Camera.main.GetComponent<TownCamera>().isInBar = true;
                    Camera.main.GetComponent<TownCamera>().isInStreet = false;
                    destination = new Vector2(-4.5f, -8f);
                    cameraPos = new Vector3(0, destination.y, -10);
                    break;
                /*case "StreetToShopPortal":
                    break;
                case "ShopToStreetPortal":
                    break;*/
            }

            player.transform.position = destination;
            Camera.main.transform.position = cameraPos;

            Debug.Log("playerPos " + player.transform.position);
            Debug.Log(Camera.main.transform.position);
        }
    }
}
