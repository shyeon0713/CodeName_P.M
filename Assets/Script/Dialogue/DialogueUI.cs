using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{

    public Button nextscript;

    public DialogueLoader dialogueLoader;   // ��� ��������
    public TMP_Text npcnametext;
    public TMP_Text dialogueText;

    public Image npc1Image;
    public Image npc2Image;

    public List<Sprite> npc1SpriteList;
    public List<Sprite> npc2SpriteList;
    public List<string> npc1SpriteNames;
    public List<string> npc2SpriteNames;
    // sprite�� happy, angry, normal �� ����
    //Json���� //�ּ��� �����ϱ� �ʾƼ� �̰��� �ۼ�


    private Dictionary<string, Sprite> npc1SpriteDict = new();
    private Dictionary<string, Sprite> npc2SpriteDict = new();

    private int currentLine = 0;

    void Start()
    {
        dialogueLoader.LoadDialogue("JSON/conversation");
        nextscript.onClick.AddListener(OutputScript);  // ��ư ����

        for (int i = 0; i < npc1SpriteList.Count; i++)
        {
            npc1SpriteDict[npc1SpriteNames[i]] = npc1SpriteList[i];
        }
        for (int i = 0; i < npc2SpriteList.Count; i++)
        {
            npc2SpriteDict[npc2SpriteNames[i]] = npc2SpriteList[i];
        }


        if (dialogueLoader.dialoguedata != null &&
        dialogueLoader.dialoguedata.dialogues != null &&
        dialogueLoader.dialoguedata.dialogues.Count > 0)    //��簡 ���� ��츦 ��������..
        {
            OutputDialogue(currentLine);
        }


    }

    void OutputScript()  // ���� ��ư ������ ���� ��� ���
    {
        currentLine++;

        if (currentLine < dialogueLoader.dialoguedata.dialogues.Count)
        {
            OutputDialogue(currentLine);
        }

    }

    void OutputDialogue(int index)
    {
        var line = dialogueLoader.dialoguedata.dialogues[index];  // var: �����Ϸ��� ������ Ÿ���� �ڵ����� �߷��ϰ� ���ִ� Ű����
        npcnametext.text = line.speaker;
        dialogueText.text = line.text;


        npc1Image.gameObject.SetActive(false);   //�̹��� ��Ȱ��Ȱ -> ������ ��
        npc2Image.gameObject.SetActive(false);     //�̹��� ��Ȱ��Ȱ -> ������ ��


        if (line.speaker == "NPC1")
        {
            npc1Image.gameObject.SetActive(true);
            npc1Image.sprite = GetSpriteFromDict(npc1SpriteDict, line.sprite);
        }
        else if (line.speaker == "NPC2")
        {
            npc2Image.gameObject.SetActive(true);
            npc2Image.sprite = GetSpriteFromDict(npc2SpriteDict, line.sprite);
        }
    }


    Sprite GetSpriteFromDict(Dictionary<string, Sprite> dict, string key)    // Dictionary�� ��ü
    {
        if (dict.TryGetValue(key, out Sprite sprite))
        {
            return sprite;
        }
        else
        {
            Debug.LogWarning($"��������Ʈ Ű '{key}'�� ã�� �� �����ϴ�.");
            return null;
        }

    }
}
