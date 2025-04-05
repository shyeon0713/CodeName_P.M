using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public TMP_Text questtext;
    public GameObject questcanvas;

    public void UpdateQuestUI()   //����Ʈ ���� �� Ȱ��ȭ
    {
      if(QuestManager.Instance.HasActiveQuest())
        {
            questcanvas.SetActive(true);
            questtext.text = $"<b>����Ʈ:</b> {QuestManager.Instance.currentQuest.questKey}";
        }
        else
        {
            questcanvas.SetActive(false);
        }
    }
}
