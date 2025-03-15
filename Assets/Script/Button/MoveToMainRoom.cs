using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToMainRoom : MonoBehaviour
{

    public Button SwitchScene;  // 생성한 버튼 컴포넌트를 연결해 둘 변수

    public void Start()
    {
        SwitchScene = GetComponent<Button>();
        SwitchScene.onClick.AddListener(GotoMainRoom);

    }
    private void GotoMainRoom()   // 프리핑룸에서 책장 버튼 클릭 시
    {
        // Debug.Log("ButtonClick");   
        SceneManager.LoadScene("MainRoom");
    }
}
