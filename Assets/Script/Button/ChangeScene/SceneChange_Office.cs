using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange_Office : MonoBehaviour
{

    public Button Bt_briefingroom;  // ������ ��ư ������Ʈ�� ������ �� ����
    public Button Bt_missionreport;

    private SFXManager sfxmanager;

    public void Start()
    {
        sfxmanager = FindObjectOfType<SFXManager>();

       // Bt_briefingroom = GetComponent<Button>();
       // Bt_missionreport = GetComponent<Button>();

        Bt_missionreport.onClick.AddListener(MissionReport);
        Bt_briefingroom.onClick.AddListener(GotoMainRoom);

    }
    private void GotoMainRoom()    // BriefingRoom ������ �̵�
    {
        SFXManager.Instance.PlaySFX("ChangeScene");  //ȿ���� ���
        // Debug.Log("ButtonClick");   
        SceneManager.LoadScene("BriefingRoom");
    }

    private void MissionReport()   // MissionReport ������ �̵�
    {
        SFXManager.Instance.PlaySFX("ChangeScene");  //ȿ���� ���
        // Debug.Log("ButtonClick");   
        SceneManager.LoadScene("MissionReport");
    }
}
