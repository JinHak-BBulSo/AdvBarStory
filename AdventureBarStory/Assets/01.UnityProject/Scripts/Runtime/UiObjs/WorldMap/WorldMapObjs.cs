using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapObjs : Singleton<WorldMapObjs>
{
    [SerializeField]
    private GameObject worldMapPrefab = default;
    private GameObject worldMapObjs = default;

    public override void Awake()
    {
        if(instance == null)
        {
            worldMapObjs = Instantiate(worldMapPrefab, transform);
            worldMapObjs.name = "WorldMapObjs";
            worldMapObjs.FindChildObj("WorldMap").SetActive(false);
        }
        base.Awake();
    }
}
