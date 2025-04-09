using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestAccept : MonoBehaviour
{
    public Button questaccept;
    void Start()
    {
       // questaccept.gameObject.SetActive(false);

        questaccept.onClick.AddListener(QuestTest);
        /*  if (!QuestManager.Instance.HasActiveQuest() &&
              QuestManager.Instance.GetQuestDataByKey("quest_001") != null)
          {
              {
                  questaccept.gameObject.SetActive(true);
              }

              questaccept.onClick.AddListener(OnquestAccept);

          }
        */
        void OnquestAccept()
        {
            QuestManager.Instance.AcceptQuest("quest_001"); // 버튼 누르면 -> 퀘스트 수락/quest_001는 key값

            SceneManager.LoadScene("Briefing");

        }

        void QuestTest()
        {
           SceneManager.LoadScene("Briefing");

        }
    }
}

