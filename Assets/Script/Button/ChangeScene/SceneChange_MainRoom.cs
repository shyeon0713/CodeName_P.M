using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange_MainRoom : MonoBehaviour
{
    public Button Bt_briefingroom;  

    private SFXManager sfxmanager;  //SFXManager ����
    public void Start()
    {
        sfxmanager = FindObjectOfType<SFXManager>();

        Bt_briefingroom  = GetComponent<Button>();
        Bt_briefingroom.onClick.AddListener(GotoBriefingRoom);
    }
    private void GotoBriefingRoom()   //å�� ��ư Ŭ�� ��
    {
        //SFX ���
        // Debug.Log("ButtonClick");   
        SceneManager.LoadScene("BriefingRoom");
    }

}
