using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChange_BriefingRoom : MonoBehaviour
{
    public Button Bt_Briefing; 
    public Button Bt_Office;
    public Button Bt_MainRoom;

    private SFXManager sfxmanager;  //SFXManager 참조

    public void Start()
    {
        sfxmanager = FindObjectOfType<SFXManager>();

       // Bt_Briefing = GetComponent<Button>();
       // Bt_Office = GetComponent<Button>();
       // Bt_MainRoom = GetComponent<Button>();

        Bt_Briefing.onClick.AddListener(GotoBriefingScene);
        Bt_Office.onClick.AddListener(GotoOffice);
        Bt_MainRoom.onClick.AddListener(GotoMainRoom);
        // 추후 이미지 변경 시, 스프라이트 변환 메서드 추가
    }
    private void GotoBriefingScene()   //Briefing 씬으로 이동
    {
        SFXManager.Instance.PlaySFX("ChangeScene");  //효과음 재생
        // Debug.Log("ButtonClick");   
        SceneManager.LoadScene("Briefing");
    }

    private void GotoOffice()   //Office 씬으로 이동
    {
        SFXManager.Instance.PlaySFX("ChangeScene");  //효과음 재생
        //Debug.Log("ButtonClick");
        SceneManager.LoadScene("Office");
    }

    private void GotoMainRoom()   //Office 씬으로 이동
    {
        SFXManager.Instance.PlaySFX("ChangeScene");  //효과음 재생
        //Debug.Log("ButtonClick");
        SceneManager.LoadScene("MainRoom");
    }

}
