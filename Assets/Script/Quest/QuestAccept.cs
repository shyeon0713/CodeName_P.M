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
            QuestManager.Instance.AcceptQuest("quest_001"); // ��ư ������ -> ����Ʈ ����/quest_001�� key��

            SceneManager.LoadScene("Briefing");

        }

        void QuestTest()
        {
           SceneManager.LoadScene("Briefing");

        }
    }
}

