using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DialogueLine
{
    public string currentline;
    public string npcname;
    public string text;
}

[System.Serializable]
public class DialogueData
{
    public List<DialogueLine> dialogues;   //List�� ��ȭ �������� -> ���Ŀ� ��Ȳ���� Dictionary�� ����
}

public class DialogueLoader : MonoBehaviour
{
    public DialogueData dialoguedata;

    private void Start()
    {
        LoadDialogue("conversation"); //json���� ��������
        foreach (var line in dialoguedata.dialogues)
        {
            Debug.Log($"{line.npcname}: {line.text}");
        }
    }

    void LoadDialogue(string file)
    {
        TextAsset dia_json = Resources.Load<TextAsset>(file);
        if (dia_json != null)
        {
            dialoguedata = JsonUtility.FromJson<DialogueData>(dia_json.text);
        }
        else
        {
            Debug.LogError("������ �ùٸ��� �ʽ��ϴ�." + file);
        }

    }
   
}
