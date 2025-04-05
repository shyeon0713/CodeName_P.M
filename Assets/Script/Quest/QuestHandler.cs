using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestHandler : MonoBehaviour
{
  private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)  //�ε�� �� ��ü ����, ���� ���� ������� �ε�Ǿ����� Ȯ��
    {
        QuestUI questUI = FindObjectOfType<QuestUI>();
        if (questUI != null)
        {
            questUI.UpdateQuestUI();
        }
    }
}
