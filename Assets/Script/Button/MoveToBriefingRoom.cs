using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovetoBriefingRoom : MonoBehaviour
{
    public Button SwitchScene;  // ������ ��ư ������Ʈ�� ������ �� ����

    public void Start()
    {
        SwitchScene = GetComponent<Button>();
        SwitchScene.onClick.AddListener(ClickCloset);

    }
    private void ClickCloset()   //å�� ��ư Ŭ�� ��
    {
        Debug.Log("ButtonClick");   
        SceneManager.LoadScene("BriefingRoom");
    }  
 
}
