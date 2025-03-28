using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    private Dictionary<string, bool> completedQuests = new Dictionary<string, bool>(); // 완료된 퀘스트 저장, Dictionary 사용

    void Awake()
    {
        // 싱글톤 패턴 적용
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 퀘스트 완료 처리
    public void CompleteQuest(string questID)
    {
        if (!completedQuests.ContainsKey(questID))  //ContainsKey(): 특정 키가 Dictionary에 존재하는지 확인하는 역할
        {
            completedQuests[questID] = true;
           // Debug.Log($"퀘스트 완료: {questID}");
        }
    }

    // 퀘스트 완료 여부 확인
    public bool IsQuestCompleted(string questID)
    {
        return completedQuests.ContainsKey(questID) && completedQuests[questID];
    }
}
