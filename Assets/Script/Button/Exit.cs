using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Button SwitchScene;  // ������ ��ư ������Ʈ�� ������ �� ����
    // Start is called before the first frame update
    void Start()
    {
        SwitchScene = GetComponent<Button>();
        SwitchScene.onClick.AddListener(GameExit);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchScene.onClick.AddListener(GameExit);  //UI ��ư ���� �� 
        if (Application.platform == RuntimePlatform.Android)  //�ȵ���̵� �ϵ���� ��ư�� ���
        {
            if (Input.GetKey(KeyCode.Home))
            {
                //home button , 
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                //back button , ������ ������ Ȯ��
            }
            else if (Input.GetKey(KeyCode.Menu))
            {
                //menu button
            }
        }
    }
    private void GameExit()
    {
        Application.Quit();  //�� ����
    }
}
