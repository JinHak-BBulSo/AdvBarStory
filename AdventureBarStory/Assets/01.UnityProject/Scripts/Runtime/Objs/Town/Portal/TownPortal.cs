using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownPortal : MonoBehaviour
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
                case "StreetToShopPortal":
                    Camera.main.GetComponent<TownCamera>().isInShop = true;
                    Camera.main.GetComponent<TownCamera>().isInStreet = false;
                    destination = new Vector2(29.5f, -4f);
                    cameraPos = new Vector3(30.5f, -2f, -10);
                    break;
                case "ShopToStreetPortal":
                    Camera.main.GetComponent<TownCamera>().isInShop = false;
                    Camera.main.GetComponent<TownCamera>().isInStreet = true;
                    destination = new Vector2(-54.5f, 1f);
                    cameraPos = new Vector3(-50.5f, 1f, -10);
                    break;
            }

            player.transform.position = destination;
            Camera.main.transform.position = cameraPos;
        }
    }
}
