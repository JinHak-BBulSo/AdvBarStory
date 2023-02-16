using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<GameEvent> gameEvents = new List<GameEvent>();

    public static EventManager instance = default;

    private GameObject scriptObj = default;

    GameEvent opening = new GameEvent("¿ÀÇÁ´×", 1, false);
    GameEvent openStage2 = new GameEvent("½£¸Ê °³¹æ", 2, false);
    GameEvent alfineEvent = new GameEvent("¾ËÇÇ³× ÇÕ·ù", 3, false);

    private void Awake()
    {
        gameEvents.Add(opening);
        gameEvents.Add(openStage2);
        gameEvents.Add(alfineEvent);

        if (instance == null)
        {
            instance = this;    
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartOpening()
    {
        scriptObj = GFunc.GetRootObj("UiObjs").FindChildObj("ScriptObjs");
        OutputScript script = scriptObj.GetComponent<OutputScript>();
        script.SetDialog(1, 62);
        scriptObj.SetActive(true);

        gameEvents[0].isFinish = true;
    }

    public void SkipOpening()
    {
        
    }
}
