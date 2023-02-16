using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameEvent
{
    public string name;
    public int ID;
    public bool isFinish;

    public GameEvent(string _name, int _ID, bool _isFinish)
    {
        name = _name;
        ID = _ID;
        isFinish = _isFinish;
    }
}
