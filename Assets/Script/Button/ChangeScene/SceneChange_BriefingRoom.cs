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

    private SFXManager sfxmanager;  //SFXManager ����

    public void Start()
    {
        sfxmanager = FindObjectOfType<SFXManager>();

       // Bt_Briefing = GetComponent<Button>();
       // Bt_Office = GetComponent<Button>();
       // Bt_MainRoom = GetComponent<Button>();

        Bt_Briefing.onClick.AddListener(GotoBriefingScene);
        Bt_Office.onClick.AddListener(GotoOffice);
        Bt_MainRoom.onClick.AddListener(GotoMainRoom);
        // ���� �̹��� ���� ��, ��������Ʈ ��ȯ �޼��� �߰�
    }
    private void GotoBriefingScene()   //Briefing ������ �̵�
    {
        SFXManager.Instance.PlaySFX("ChangeScene");  //ȿ���� ���
        // Debug.Log("ButtonClick");   
        SceneManager.LoadScene("Briefing");
    }

    private void GotoOffice()   //Office ������ �̵�
    {
        SFXManager.Instance.PlaySFX("ChangeScene");  //ȿ���� ���
        //Debug.Log("ButtonClick");
        SceneManager.LoadScene("Office");
    }

    private void GotoMainRoom()   //Office ������ �̵�
    {
        SFXManager.Instance.PlaySFX("ChangeScene");  //ȿ���� ���
        //Debug.Log("ButtonClick");
        SceneManager.LoadScene("MainRoom");
    }

}
