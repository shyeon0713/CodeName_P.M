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

    public Image npc1Image;
    public Image npc2Image;

    public List<Sprite> npc1SpriteList;
    public List<Sprite> npc2SpriteList;
    public List<string> npc1SpriteNames;
    public List<string> npc2SpriteNames;
    // sprite는 happy, angry, normal 로 구성
    //Json에서 //주석을 지원하기 않아서 이곳에 작성


    private Dictionary<string, Sprite> npc1SpriteDict = new();
    private Dictionary<string, Sprite> npc2SpriteDict = new();

    private int currentLine = 0;

    void Start()
    {
        dialogueLoader.LoadDialogue("JSON/conversation");
        nextscript.onClick.AddListener(OutputScript);  // 버튼 연결

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
        dialogueLoader.dialoguedata.dialogues.Count > 0)    //대사가 없을 경우를 생각못함..
        {
            OutputDialogue(currentLine);
        }


    }

    void OutputScript()  // 다음 버튼 누르면 다음 대사 출력
    {
        currentLine++;

        if (currentLine < dialogueLoader.dialoguedata.dialogues.Count)
        {
            OutputDialogue(currentLine);
        }

    }

    void OutputDialogue(int index)
    {
        var line = dialogueLoader.dialoguedata.dialogues[index];  // var: 컴파일러가 변수의 타입을 자동으로 추론하게 해주는 키워드
        npcnametext.text = line.speaker;
        dialogueText.text = line.text;


        npc1Image.gameObject.SetActive(false);   //이미지 비활성활 -> 시작할 때
        npc2Image.gameObject.SetActive(false);     //이미지 비활성활 -> 시작할 때


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


    Sprite GetSpriteFromDict(Dictionary<string, Sprite> dict, string key)    // Dictionary로 교체
    {
        if (dict.TryGetValue(key, out Sprite sprite))
        {
            return sprite;
        }
        else
        {
            Debug.LogWarning($"스프라이트 키 '{key}'를 찾을 수 없습니다.");
            return null;
        }

    }
}
