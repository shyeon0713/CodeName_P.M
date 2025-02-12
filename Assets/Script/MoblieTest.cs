using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoblieTest : MonoBehaviour
{
    [Header("Debug Test")]
    [SerializeField]
    private TextMeshProUGUI textTouch;

    private void Update()
    {
        OnSingleTouch();
    }

    private void OnSingleTouch()
    {
        if ( Input.touchCount > 0)  //���� ��ġ�� �հ��� ������ 1�� �̻��϶� (��ġ �� �Է��� ���� ���)
        {
            Touch touch = Input.GetTouch(0); //-> ���� ��ġ�̱� ����

            if ( touch.phase == TouchPhase.Began)   // ��ġ�� ���°� ��ġ ������ �� -> Touch Begin ���
            {
                textTouch.text = "Touch Begin";
            }


            else if (touch.phase == TouchPhase.Ended)   // ��ġ�� ���°� ��ġ ������ ���� -> Touch End ���
            {
                textTouch.text = "Touch End";
            }

        }
    }

}
