using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToMainRoom : MonoBehaviour
{

    public Button SwitchScene;  // ������ ��ư ������Ʈ�� ������ �� ����

    public void Start()
    {
        SwitchScene = GetComponent<Button>();
        SwitchScene.onClick.AddListener(GotoMainRoom);

    }
    private void GotoMainRoom()   // �����η뿡�� å�� ��ư Ŭ�� ��
    {
        // Debug.Log("ButtonClick");   
        SceneManager.LoadScene("MainRoom");
    }
}
