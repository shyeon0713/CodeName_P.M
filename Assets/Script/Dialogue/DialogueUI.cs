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

    private int currentLine = 0;

    void Start()
    {
        ShowLine(currentLine);
    }

    void OutputScript()  // ���� ��ư ������ ���� ��� ���
    {
          currentLine++;
          if (currentLine < dialogueLoader.dialogueData.dialogues.Count)
          {
                ShowLine(currentLine);
          }
    }

    void ShowLine(int index)
    {
        var line = dialogueLoader.dialoguedata.dialogues[index];  // var: �����Ϸ��� ������ Ÿ���� �ڵ����� �߷��ϰ� ���ִ� Ű����
        npcnametext.text = line.npcname;
        dialogueText.text = line.text;
    }
}
