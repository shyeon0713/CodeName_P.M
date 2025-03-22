using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MoveToBriefin : MonoBehaviour
{
    public Button SwitchScene;  // ������ ��ư ������Ʈ�� ������ �� ����

    public void Start()
    {
        SwitchScene = GetComponent<Button>();
        SwitchScene.onClick.AddListener(GotoBriefingScene);

    }
    private void GotoBriefingScene()   //å�� ��ư Ŭ�� ��
    {
        // Debug.Log("ButtonClick");   
        SceneManager.LoadScene("Briefing");
    }

}
