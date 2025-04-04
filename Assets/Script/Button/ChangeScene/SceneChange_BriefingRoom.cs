using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChange_BriefingRoom : MonoBehaviour
{
    public Button Bt_Office;
    public Button Bt_MainRoom;

    private SFXManager sfxmanager;  //SFXManager ����

    public void Start()
    {
        sfxmanager = FindObjectOfType<SFXManager>();

       // Bt_Briefing = GetComponent<Button>();
       // Bt_Office = GetComponent<Button>();
       // Bt_MainRoom = GetComponent<Button>();

      
        Bt_Office.onClick.AddListener(GotoOffice);
        Bt_MainRoom.onClick.AddListener(GotoMainRoom);
        // ���� �̹��� ���� ��, ��������Ʈ ��ȯ �޼��� �߰�
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
