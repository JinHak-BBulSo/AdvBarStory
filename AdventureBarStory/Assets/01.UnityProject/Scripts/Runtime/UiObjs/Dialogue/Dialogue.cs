using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("���ϴ� ĳ���� �̸�")]
    public string chaName;

    [Tooltip("��� ����")]
    public string[] contexts;
}

[System.Serializable]
public class DialogueEvent
{
    public string eventName;

    public Vector2 line; // ���۳ѹ�, ����ѹ�
    public Dialogue[] dialogues;
}
