using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange_MainRoom : MonoBehaviour
{
    public Button Bt_briefingroom;  

    private SFXManager sfxmanager;  //SFXManager 참조
    public void Start()
    {
        sfxmanager = FindObjectOfType<SFXManager>();

        Bt_briefingroom  = GetComponent<Button>();
        Bt_briefingroom.onClick.AddListener(GotoBriefingRoom);
    }
    private void GotoBriefingRoom()   //책장 버튼 클릭 시
    {
        //SFX 재생
        // Debug.Log("ButtonClick");   
        SceneManager.LoadScene("BriefingRoom");
    }

}
