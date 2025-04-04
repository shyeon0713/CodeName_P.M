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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)  //로드된 씬 자체 정보, 씬이 더떤 방식으로 로드되었는지 확인
    {
        QuestUI questUI = FindObjectOfType<QuestUI>();
        if (questUI != null)
        {
            questUI.UpdateQuestUI();
        }
    }
}
