using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Button SwitchScene;  // 생성한 버튼 컴포넌트를 연결해 둘 변수
    // Start is called before the first frame update
    void Start()
    {
        SwitchScene = GetComponent<Button>();
        SwitchScene.onClick.AddListener(GameExit);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchScene.onClick.AddListener(GameExit);  //UI 버튼 누를 시 
        if (Application.platform == RuntimePlatform.Android)  //안드로이드 하드웨어 버튼의 경우
        {
            if (Input.GetKey(KeyCode.Home))
            {
                //home button , 
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                //back button , 종료할 것인지 확인
            }
            else if (Input.GetKey(KeyCode.Menu))
            {
                //menu button
            }
        }
    }
    private void GameExit()
    {
        Application.Quit();  //앱 종료
    }
}
