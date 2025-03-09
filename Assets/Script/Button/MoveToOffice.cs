using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToOffice : MonoBehaviour
{
  
    // 버튼 클릭 시 호출될 메소드
    public void OnButtonClick()
    {
    
        SceneManager.LoadScene("Office");
    }
}
