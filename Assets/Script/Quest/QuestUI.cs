using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public TMP_Text questtext;
    public GameObject questcanvas;

    public void UpdateQuestUI()   //퀘스트 수령 시 활성화
    {
      if(QuestManager.Instance.HasActiveQuest())
        {
            questcanvas.SetActive(true);
            questtext.text = $"<b>퀘스트:</b> {QuestManager.Instance.currentQuest.questKey}";
        }
        else
        {
            questcanvas.SetActive(false);
        }
    }
}
