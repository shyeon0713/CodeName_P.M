using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MoveToOffice : MonoBehaviour
{
    public Button SwitchScene;  // ������ ��ư ������Ʈ�� ������ �� ����
    public void Start()
    {
        SwitchScene = GetComponent<Button>();
        SwitchScene.onClick.AddListener(GotoOffice);

    }
    private void GotoOffice()   //���� ��ư Ŭ�� ��
    {
        //Debug.Log("ButtonClick");
        SceneManager.LoadScene("Office");
    }

}
