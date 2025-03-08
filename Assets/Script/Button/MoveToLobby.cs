using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToLobby : MonoBehaviour
{
  
    // 버튼 클릭 시 호출될 메소드
    public void OnButtonClick()
    {
        // 'TargetScene'은 이동하고자 하는 씬의 이름입니다.
        // 씬 이름을 정확히 입력하세요.
        SceneManager.LoadScene("MainRoom");
    }
}
