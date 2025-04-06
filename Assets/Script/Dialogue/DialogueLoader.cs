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
    public List<DialogueLine> dialogues;   //List로 대화 가져오기 -> 추후에 상황보고 Dictionary로 수정
}

public class DialogueLoader : MonoBehaviour
{
    public DialogueData dialoguedata;

    private void Start()
    {
        LoadDialogue("conversation"); //json파일 가져오기
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
            Debug.LogError("파일이 올바르지 않습니다." + file);
        }

    }
   
}
