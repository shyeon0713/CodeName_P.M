using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneChange_Title : MonoBehaviour
{
    public Button Bt_MainRoom;  // ������ ��ư ������Ʈ�� ������ �� ����

    private SFXManager sfxmanager;
    public void Start()
    {
        sfxmanager = FindObjectOfType<SFXManager>();

        Bt_MainRoom = GetComponent<Button>();

        Bt_MainRoom.onClick.AddListener(GotoMainRoom);

    }

    private void GotoMainRoom()
    {
        SceneManager.LoadScene("MainRoom");
    }
}
