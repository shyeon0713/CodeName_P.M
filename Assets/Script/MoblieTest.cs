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
        if ( Input.touchCount > 0)  //현재 터치한 손가락 개수가 1개 이상일때 (터치 및 입력이 있을 경우)
        {
            Touch touch = Input.GetTouch(0); //-> 단일 터치이기 때문

            if ( touch.phase == TouchPhase.Began)   // 터치의 상태가 터치 시작일 때 -> Touch Begin 출력
            {
                textTouch.text = "Touch Begin";
            }


            else if (touch.phase == TouchPhase.Ended)   // 터치의 상태가 터치 종료일 ㄸ때 -> Touch End 출력
            {
                textTouch.text = "Touch End";
            }

        }
    }

}
