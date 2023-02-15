using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance = default;
    [SerializeField]
    private GameObject scriptObj = default;

    private bool openingSkip = false;
    private bool openingStart = false;
    private bool openingMoveStart = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartOpening()
    {
        scriptObj = GFunc.GetRootObj("UiObjs").FindChildObj("ScriptObjs");
        OutputOpeningScript script = scriptObj.FindChildObj("Script").GetComponent<OutputOpeningScript>();
        script.SetDialog(1, 62);
        scriptObj.SetActive(true);
    }

    public void SkipOpening()
    {
        openingSkip = true;
        openingStart = true;
    }
}
