using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDataManager : MonoBehaviour
{
    public static ScriptDataManager instance;
    [SerializeField]
    string csvFileName;

    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();

    public static bool isFinish = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DialogueParser theParser = GetComponent<DialogueParser>();
            Dialogue[] dialogues = theParser.Parse(csvFileName);

            for(int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            isFinish = true;
            DontDestroyOnLoad(gameObject);
        }
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
