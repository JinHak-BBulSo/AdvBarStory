using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public List<GameEvent> gameEvents = new List<GameEvent>();

    private GameObject scriptObj = default;

    GameEvent opening = new GameEvent("¿ÀÇÁ´×", 1, false);
    GameEvent openStage2 = new GameEvent("½£¸Ê °³¹æ", 2, false);
    GameEvent alfineEvent = new GameEvent("¾ËÇÇ³× ÇÕ·ù", 3, false);

    public override void Awake()
    {
        base.Awake();
        gameEvents.Add(opening);
        gameEvents.Add(openStage2);
        gameEvents.Add(alfineEvent);
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
