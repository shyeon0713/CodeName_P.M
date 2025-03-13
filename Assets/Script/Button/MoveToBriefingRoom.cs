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
        if (Input.touchCount > 0)  //현재 터치한 손가락 개수가 1개 이상일때 (터치 및 입력이 있을 경우)
        {
            Touch touch = Input.GetTouch(0); //-> 단일 터치이기 때문

            if (touch.phase == TouchPhase.Began)   // 터치의 상태가 터치 시작일 때 -> Touch Begin 출력
            {
                //UI animation 실행
                //2초 정지
                // 'TargetScene'은 이동하고자 하는 씬의 이름입니다.
                // 씬 이름을 정확히 입력하세요.
                SceneManager.LoadScene("BriefingRoom");
            }


            else if (touch.phase == TouchPhase.Ended)   // 터치의 상태가 터치 종료일 ㄸ때 -> Touch End 출력
            {
               
            }

        }
    }
 
}
