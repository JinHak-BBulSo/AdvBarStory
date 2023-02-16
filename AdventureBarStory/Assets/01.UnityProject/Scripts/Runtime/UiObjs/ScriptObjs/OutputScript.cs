using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OutputScript : MonoBehaviour
{
    private float scriptDelay = 0.05f;
    private Dialogue[] scriptDialogues = default;

    public int start, end;
    private int index = 0;

    public int Index
    {
        get { return index; }
    }

    private int dialIndex = 0;
    private bool isLineFinish = false;

    private string contextScripts = default;
    private string context = default;
    private string chaName = default;

    [SerializeField]
    Sprite[] charSprites = default;

    TMP_Text nameTxt = default;
    TMP_Text scriptTxt = default;
    GameObject nameObj = default;
    GameObject scriptObj = default;
    GameObject charImageObj = default;

    private float skipCheckTime = 0;

    void Awake()
    {
        nameTxt = gameObject.FindChildObj("NameTxt").GetComponent<TMP_Text>();
        scriptTxt = gameObject.FindChildObj("ScriptTxt").GetComponent<TMP_Text>();
        nameObj = gameObject.FindChildObj("ScriptCharName");
        scriptObj = gameObject.FindChildObj("Script");
        charImageObj = gameObject.FindChildObj("ScriptCharImage");
    }

    private void OnEnable()
    {
        scriptDialogues = ScriptDataManager.instance.GetDialogue(start, end);
        index = start - 1;

        chaName = scriptDialogues[index].chaName;
        context = scriptDialogues[index].contexts[0];
        StartCoroutine(SetScript());

        CheckNameNull();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            skipCheckTime += Time.deltaTime;
            if(skipCheckTime > 1f)
            {
                OnClickUpdateScript();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            skipCheckTime = 0;
        }
    }

    public void OnClickUpdateScript()
    {
        if (isLineFinish)
        {
            isLineFinish = false;            

            if (dialIndex == scriptDialogues[index].contexts.Count() - 1)
            {
                index++;
                if(index == end)
                {
                    gameObject.SetActive(false);
                    StopAllCoroutines();

                    return;
                }
                dialIndex = 0;
                chaName = scriptDialogues[index].chaName;
                context = scriptDialogues[index].contexts[dialIndex];
                StartCoroutine(SetScript());
            }
            else
            {         
                dialIndex++;
                chaName = scriptDialogues[index].chaName;
                context = scriptDialogues[index].contexts[dialIndex];
                StartCoroutine(SetScript());
            }
        }
        else
        {
            StopAllCoroutines();
            isLineFinish = true;
            scriptTxt.text = context;
        }
    }

    IEnumerator SetScript()
    {
        nameTxt.text = chaName;
        CheckNameNull();

        scriptTxt.text = "";
        contextScripts = "";

        foreach (char c in context)
        {
            yield return new WaitForSeconds(scriptDelay);

            contextScripts += c;
            scriptTxt.text = contextScripts;
        }
        isLineFinish = true;
    }

    void CheckNameNull()
    {
        if (chaName != "null")
        {
            if (!nameObj.gameObject.activeSelf)
            {
                charImageObj.SetActive(true);
                nameObj.SetActive(true);
            }
            nameTxt.text = chaName;
            switch (chaName)
            {
                case "Siela":
                    charImageObj.GetComponent<Image>().sprite = charSprites[0];
                    break;
                case "Fred":
                    charImageObj.GetComponent<Image>().sprite = charSprites[1];
                    break;
                case "Kamerina":
                    charImageObj.GetComponent<Image>().sprite = charSprites[2];
                    break;
                case "Strange Man":
                    charImageObj.GetComponent<Image>().sprite = charSprites[3];
                    break;
                case "Alfine":
                    charImageObj.GetComponent<Image>().sprite = charSprites[4];
                    break;
            }
        }
        else
        {
            charImageObj.SetActive(false);
            nameObj.SetActive(false);
        }
    }

    public void SetDialog(int _start, int _end)
    {
        start = _start;
        end = _end;
        scriptDialogues = ScriptDataManager.instance.GetDialogue(start, end);
        index = start - 1;
    }
}
