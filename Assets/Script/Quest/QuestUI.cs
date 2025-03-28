using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public TMP_Text questText;
    public Toggle questToggle; //Toggle 버튼 

    void Start()
    {
        questText.gameObject.SetActive(false);
        questToggle.onValueChanged.AddListener(ToggleQuest);
    }
    public void ToggleQuest(bool isOn)
    {
        questText.gameObject.SetActive(isOn);
    }
    public void SetQuest(string questTitle, string questDescription)
    {
        questText.text = $"<b>{questTitle}</b>\n{questDescription}";
    }

    // Toggle 메뉴에서 On Click() 설정
}