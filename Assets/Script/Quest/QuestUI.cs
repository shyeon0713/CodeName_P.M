using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public TMP_Text questText;
    public Toggle questToggle; //Toggle ��ư 

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

    // Toggle �޴����� On Click() ����
}