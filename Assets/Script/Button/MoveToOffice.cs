using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToOffice : MonoBehaviour
{
  
    // ��ư Ŭ�� �� ȣ��� �޼ҵ�
    public void OnButtonClick()
    {
    
        SceneManager.LoadScene("Office");
    }
}
