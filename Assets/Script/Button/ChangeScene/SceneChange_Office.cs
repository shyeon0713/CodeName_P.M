using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange_Office : MonoBehaviour
{

    public Button Bt_briefingroom;  // 생성한 버튼 컴포넌트를 연결해 둘 변수
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
    private void GotoMainRoom()    // BriefingRoom 씬으로 이동
    {
        SFXManager.Instance.PlaySFX("ChangeScene");  //효과음 재생
        // Debug.Log("ButtonClick");   
        SceneManager.LoadScene("BriefingRoom");
    }

    private void MissionReport()   // MissionReport 씬으로 이동
    {
        SFXManager.Instance.PlaySFX("ChangeScene");  //효과음 재생
        // Debug.Log("ButtonClick");   
        SceneManager.LoadScene("MissionReport");
    }
}
