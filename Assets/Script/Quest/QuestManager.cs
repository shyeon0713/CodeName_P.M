using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;


    [System.Serializable]
    public struct CurrentQuest  //현재 퀘스트 
    {
        public string questKey;      // 퀘스트 식별자 (예: "quest_001")
        public int progress;         // 진행도 (예: 0~10)
        public bool hasReceived;     // 해당 퀘스트를 받은 적 있는지 여부
    }

    public class QuestData
    {
        public string id;         // 퀘스트 고유 ID
        public string title;      // 퀘스트 제목
        public string description; // 퀘스트 설명
        public int goalCount;     // 목표 카운트
    }

    private Dictionary<string, bool> completedQuests = new(); // 완료된 퀘스트 저장, Dictionary 사용
    public Dictionary<string, QuestData> questDataDict = new();

    public CurrentQuest currentQuest;
    //퀘스트 참조를 어떤 방식으로 진행할지 감이 안잡힘
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

    public bool HasActiveQuest()
    {
        return !string.IsNullOrEmpty(currentQuest.questKey) && currentQuest.hasReceived;
        //IsNullOrEmpty -> 문자열이 비어있거나 null인지 확인할 때 사용하는 유틸리티 메서드
    }

    public void AcceptQuest(string questKey)  //퀘스트를 수령할 경우
    {
        currentQuest.questKey = questKey;
        currentQuest.progress = 0;
        currentQuest.hasReceived = true;
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

    public QuestData GetQuestDataByKey(string key)
    {
        questDataDict.TryGetValue(key, out var quest);
        return quest;
    }

    // Dictionary 초기화용
    public void InitializeQuestData(List<QuestData> questList)
    {
        questDataDict.Clear();
        foreach (var quest in questList)
        {
            if (!questDataDict.ContainsKey(quest.id))
                questDataDict.Add(quest.id, quest);
        }
    }
}
