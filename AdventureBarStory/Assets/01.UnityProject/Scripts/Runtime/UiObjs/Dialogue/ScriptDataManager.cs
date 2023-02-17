using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDataManager : Singleton<ScriptDataManager>
{
    [SerializeField]
    string csvFileName;

    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();

    public static bool isFinish = false;

    public override void Awake()
    {
        base.Awake();
        DialogueParser theParser = GetComponent<DialogueParser>();
        Dialogue[] dialogues = theParser.Parse(csvFileName);

        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogueDic.Add(i + 1, dialogues[i]);
        }
        isFinish = true;
    }

    public Dialogue[] GetDialogue(int StartNum, int EndNum)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();

        for(int i = 0; i <= EndNum - StartNum; i++)
        {
            dialogueList.Add(dialogueDic[StartNum + i]);
        }

        return dialogueList.ToArray();
    }
}
