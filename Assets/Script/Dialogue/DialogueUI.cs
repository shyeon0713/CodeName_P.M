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

    public Image characterImage;
    public Sprite[] characterSprites;
    public string[] spriteNames;

    private int currentLine = 0;

    void Start()
    {
        ShowLine(currentLine);
    }

    void OutputScript()  // ���� ��ư ������ ���� ��� ���
    {
          currentLine++;
        if (currentLine < dialogueLoader.dialoguedata.dialogues.Count)
        {
            ShowLine(currentLine);
        }

    }

    void ShowLine(int index)
    {
        var line = dialogueLoader.dialoguedata.dialogues[index];  // var: �����Ϸ��� ������ Ÿ���� �ڵ����� �߷��ϰ� ���ִ� Ű����
        npcnametext.text = line.speaker;
        dialogueText.text = line.text;



        if (!string.IsNullOrEmpty(line.sprite))
        {
            int spriteIndex = System.Array.IndexOf(spriteNames, line.sprite);
            if (spriteIndex >= 0 && spriteIndex < characterSprites.Length)
            {
                characterImage.sprite = characterSprites[spriteIndex];
            }
            else
            {
                Debug.LogWarning($"��������Ʈ '{line.sprite}'�� ã�� �� �����ϴ�.");
            }
        }
    }
}
