using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToLobby : MonoBehaviour
{
  
    // ��ư Ŭ�� �� ȣ��� �޼ҵ�
    public void OnButtonClick()
    {
        // 'TargetScene'�� �̵��ϰ��� �ϴ� ���� �̸��Դϴ�.
        // �� �̸��� ��Ȯ�� �Է��ϼ���.
        SceneManager.LoadScene("MainRoom");
    }
}
