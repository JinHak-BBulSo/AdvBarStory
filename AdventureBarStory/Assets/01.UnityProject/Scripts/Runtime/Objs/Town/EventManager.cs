using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance = default;
    private GameObject scriptObj = default;

    private bool openingSkip = false;
    private bool openingStart = false;


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
        scriptObj = GameObject.Find("Script");
        OutputOpeningScript script = scriptObj.GetComponent<OutputOpeningScript>();
        script.SetDialog(1, 62);
    }

    public void SkipOpening()
    {
        openingSkip = true;
        openingStart = true;
    }
}
