using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovetoBriefingRoom : MonoBehaviour
{
    public Button SwitchScene;  // 생성한 버튼 컴포넌트를 연결해 둘 변수

    public void Start()
    {
        SwitchScene = GetComponent<Button>();
        SwitchScene.onClick.AddListener(ClickCloset);

    }
    private void ClickCloset()   //책장 버튼 클릭 시
    {
        Debug.Log("ButtonClick");   
        SceneManager.LoadScene("BriefingRoom");
    }  
 
}
