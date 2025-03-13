using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToBriefingRoom : MonoBehaviour
{

    private void Update()
    {
        OnSingleTouch();
    }
    private void OnSingleTouch()
    {
        if (Input.touchCount > 0)  //���� ��ġ�� �հ��� ������ 1�� �̻��϶� (��ġ �� �Է��� ���� ���)
        {
            Touch touch = Input.GetTouch(0); //-> ���� ��ġ�̱� ����

            if (touch.phase == TouchPhase.Began)   // ��ġ�� ���°� ��ġ ������ �� -> Touch Begin ���
            {
                //UI animation ����
                //2�� ����
                // 'TargetScene'�� �̵��ϰ��� �ϴ� ���� �̸��Դϴ�.
                // �� �̸��� ��Ȯ�� �Է��ϼ���.
                SceneManager.LoadScene("BriefingRoom");
            }


            else if (touch.phase == TouchPhase.Ended)   // ��ġ�� ���°� ��ġ ������ ���� -> Touch End ���
            {
               
            }

        }
    }
 
}
