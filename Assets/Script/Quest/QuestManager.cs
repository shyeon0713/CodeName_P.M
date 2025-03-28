using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    private Dictionary<string, bool> completedQuests = new Dictionary<string, bool>(); // �Ϸ�� ����Ʈ ����, Dictionary ���

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
}
