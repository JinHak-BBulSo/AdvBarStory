using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("말하는 캐릭터 이름")]
    public string chaName;

    [Tooltip("대사 내용")]
    public string[] contexts;
}

[System.Serializable]
public class DialogueEvent
{
    public string eventName;

    public Vector2 line; // 시작넘버, 엔드넘버
    public Dialogue[] dialogues;
}
