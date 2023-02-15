using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OutputOpeningScript : MonoBehaviour
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

    [SerializeField]
    TMP_Text nameTxt = default;
    [SerializeField]
    TMP_Text scriptTxt = default;
    [SerializeField]
    GameObject nameObj = default;
    [SerializeField]
    GameObject scriptObj = default;
    [SerializeField]
    GameObject charImageObj = default;

    private void OnEnable()
    {
        scriptDialogues = ScriptDataManager.instance.GetDialogue(start, end);
        index = start - 1;

        chaName = scriptDialogues[index].chaName;
        context = scriptDialogues[index].contexts[0];
        StartCoroutine(SetScript());

        CheckNameNull();
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
                    nameObj.SetActive(false);
                    scriptObj.SetActive(false);
                    charImageObj.SetActive(false);

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
