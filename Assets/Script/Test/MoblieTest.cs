using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoblieTest : MonoBehaviour
{
    [Header("Debug Test")]
    [SerializeField]   // Unity가 필드를 직렬화하도록 강제하는 속성
    private TextMeshProUGUI textTouch;


    [Header("Camera Zoom In / Out")]   //카메라 생성 -> 터치시간에 따라 줌인 줌아웃 구현
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float zoomSpeed = 1.0f;

    private void Update()
    {
        //OnSingleTouch();  // 단일 터치
        // OnMultiTouch();  // 다중 터치
        OncamerZoom();
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

    private void OnMultiTouch()
    {
        if (Input.touchCount > 0)  // 현재 터치한 손가락 개수가 1개 이상일때 (터치 및 입력이 있을 경우)
        {
            textTouch.text = "";

            //멀티 터치이기 때문에 현재 터치한 모든 정보를 살펴봄
            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);  // i번째 터치에 대한 정보 
                int index = touch.fingerId;  // i번째 터치의 ID 값
                Vector2 position = touch.position;  // i번째 터치의 위치
                TouchPhase phase = touch.phase; // i번째 터치의 상태

                if (phase == TouchPhase.Began)  // i번째 터치의 상태 : 터치하는 순간 1회 호출 
                {
                    // 원하는 기능 구현
                }
                else if (phase == TouchPhase.Moved)  // i번째 터치의 상태 : 터치 후 드래그할 때 계속
                {
                    // 원하는 기능 구현
                }
                else if (phase == TouchPhase.Stationary)  // i번째 터치의 상태 : 터치 상태로 가만히 있을 때
                {
                    // 원하는 기능 구현
                }
                else if (phase == TouchPhase.Ended)  // i번째 터치의 상태 : 터치를 종료할 때 1회
                {
                    // 원하는 기능 구현
                }
                else if (phase == TouchPhase.Canceled)  // i번째 터치의 상태 : 시스템에 의해 터치를 종료할 때 1회
                {
                    // 원하는 기능 구현
                }

            }
        }
    }

    private void OncamerZoom()
    {  // 실제 게임에서는 게임모드 (2d /3d), 게임 환경에 따라 카메라의 줌 설정이 다르니 꼭 확인하기

        if (Input.touchCount != 2)  // 터치 두개의 터치가 감지되었을 경우
        {
            return;
        }
        Touch firstTouch = Input.GetTouch(0);   //첫번째 터치 정보
        Touch secondTouch = Input.GetTouch(1);  // 두번째

        // 현재 위치- 위치 변화량을 계산하여 직전 프레임의 터치 위치를 구함
        Vector2 firstTouchPPosition = firstTouch.position - firstTouch.deltaPosition;
        Vector2 secondTouchPPosition = secondTouch.position - secondTouch.deltaPosition;

        // 과거 두개의 터치 사이의 거리
        float PastpositionDistance = (firstTouchPPosition - secondTouchPPosition).magnitude;
        // 현재 두개의 터치 사이의 거리
        float CurpostionDistance = (firstTouch.position - secondTouch.position).magnitude;

        //줌 수치 값 -> 얼만큼을 줌인/아웃을 할 지 결정
        float ZoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomSpeed;

        // 직전 프레임의 두 터치 사이의 거리가 현재보다 작을 경우 -> 줌 인
        if (PastpositionDistance < CurpostionDistance)
        {
            cameraTransform.position += Vector3.back * ZoomModifier * Time.deltaTime;

        }

        // 직전 프레임의 두 터치 사이의 거리가 현재보다 클 경우 -> 줌 아웃
        else if (PastpositionDistance > CurpostionDistance)
        {
            cameraTransform.position += Vector3.forward * ZoomModifier * Time.deltaTime;

        }
    }


}
