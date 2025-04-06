using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{

    public Button nextscript;

    public DialogueLoader dialogueLoader;   // 대사 가져오기
    public TMP_Text npcnametext;
    public TMP_Text dialogueText;

    private int currentLine = 0;

    void Start()
    {
        ShowLine(currentLine);
    }

    void OutputScript()  // 다음 버튼 누르면 다음 대사 출력
    {
          currentLine++;
          if (currentLine < dialogueLoader.dialogueData.dialogues.Count)
          {
                ShowLine(currentLine);
          }
    }

    void ShowLine(int index)
    {
        var line = dialogueLoader.dialoguedata.dialogues[index];  // var: 컴파일러가 변수의 타입을 자동으로 추론하게 해주는 키워드
        npcnametext.text = line.npcname;
        dialogueText.text = line.text;
    }
}
