using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneChange_Title : MonoBehaviour
{
    public Button Bt_MainRoom;  // 생성한 버튼 컴포넌트를 연결해 둘 변수

    private SFXManager sfxmanager;
    public void Start()
    {
        sfxmanager = FindObjectOfType<SFXManager>();

       // Bt_MainRoom = GetComponent<Button>();

        Bt_MainRoom.onClick.AddListener(GotoMainRoom);

    }

    private void GotoMainRoom()
    {
        SFXManager.Instance.PlaySFX("ChangeScene");  //효과음 재생
        SceneManager.LoadScene("MainRoom");
    }
}
