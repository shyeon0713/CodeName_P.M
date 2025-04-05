using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;


    [System.Serializable]
    public struct CurrentQuest  //���� ����Ʈ 
    {
        public string questKey;      // ����Ʈ �ĺ��� (��: "quest_001")
        public int progress;         // ���൵ (��: 0~10)
        public bool hasReceived;     // �ش� ����Ʈ�� ���� �� �ִ��� ����
    }

    public class QuestData
    {
        public string id;         // ����Ʈ ���� ID
        public string title;      // ����Ʈ ����
        public string description; // ����Ʈ ����
        public int goalCount;     // ��ǥ ī��Ʈ
    }

    private Dictionary<string, bool> completedQuests = new(); // �Ϸ�� ����Ʈ ����, Dictionary ���
    public Dictionary<string, QuestData> questDataDict = new();

    public CurrentQuest currentQuest;
    //����Ʈ ������ � ������� �������� ���� ������
    void Awake()
    {
        // �̱��� ���� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool HasActiveQuest()
    {
        return !string.IsNullOrEmpty(currentQuest.questKey) && currentQuest.hasReceived;
        //IsNullOrEmpty -> ���ڿ��� ����ְų� null���� Ȯ���� �� ����ϴ� ��ƿ��Ƽ �޼���
    }

    public void AcceptQuest(string questKey)  //����Ʈ�� ������ ���
    {
        currentQuest.questKey = questKey;
        currentQuest.progress = 0;
        currentQuest.hasReceived = true;
    }

    // ����Ʈ �Ϸ� ó��
    public void CompleteQuest(string questID)
    {
        if (!completedQuests.ContainsKey(questID))  //ContainsKey(): Ư�� Ű�� Dictionary�� �����ϴ��� Ȯ���ϴ� ����
        {
            completedQuests[questID] = true;
            // Debug.Log($"����Ʈ �Ϸ�: {questID}");
        }
    }

    // ����Ʈ �Ϸ� ���� Ȯ��
    public bool IsQuestCompleted(string questID)
    {
        return completedQuests.ContainsKey(questID) && completedQuests[questID];
    }

    public QuestData GetQuestDataByKey(string key)
    {
        questDataDict.TryGetValue(key, out var quest);
        return quest;
    }

    // Dictionary �ʱ�ȭ��
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
