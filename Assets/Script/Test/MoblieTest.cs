using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoblieTest : MonoBehaviour
{
    [Header("Debug Test")]
    [SerializeField]   // Unity�� �ʵ带 ����ȭ�ϵ��� �����ϴ� �Ӽ�
    private TextMeshProUGUI textTouch;


    [Header("Camera Zoom In / Out")]   //ī�޶� ���� -> ��ġ�ð��� ���� ���� �ܾƿ� ����
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float zoomSpeed = 1.0f;

    private void Update()
    {
        //OnSingleTouch();  // ���� ��ġ
        // OnMultiTouch();  // ���� ��ġ
        OncamerZoom();
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

    private void OnMultiTouch()
    {
        if (Input.touchCount > 0)  // ���� ��ġ�� �հ��� ������ 1�� �̻��϶� (��ġ �� �Է��� ���� ���)
        {
            textTouch.text = "";

            //��Ƽ ��ġ�̱� ������ ���� ��ġ�� ��� ������ ���캽
            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);  // i��° ��ġ�� ���� ���� 
                int index = touch.fingerId;  // i��° ��ġ�� ID ��
                Vector2 position = touch.position;  // i��° ��ġ�� ��ġ
                TouchPhase phase = touch.phase; // i��° ��ġ�� ����

                if (phase == TouchPhase.Began)  // i��° ��ġ�� ���� : ��ġ�ϴ� ���� 1ȸ ȣ�� 
                {
                    // ���ϴ� ��� ����
                }
                else if (phase == TouchPhase.Moved)  // i��° ��ġ�� ���� : ��ġ �� �巡���� �� ���
                {
                    // ���ϴ� ��� ����
                }
                else if (phase == TouchPhase.Stationary)  // i��° ��ġ�� ���� : ��ġ ���·� ������ ���� ��
                {
                    // ���ϴ� ��� ����
                }
                else if (phase == TouchPhase.Ended)  // i��° ��ġ�� ���� : ��ġ�� ������ �� 1ȸ
                {
                    // ���ϴ� ��� ����
                }
                else if (phase == TouchPhase.Canceled)  // i��° ��ġ�� ���� : �ý��ۿ� ���� ��ġ�� ������ �� 1ȸ
                {
                    // ���ϴ� ��� ����
                }

            }
        }
    }

    private void OncamerZoom()
    {  // ���� ���ӿ����� ���Ӹ�� (2d /3d), ���� ȯ�濡 ���� ī�޶��� �� ������ �ٸ��� �� Ȯ���ϱ�

        if (Input.touchCount != 2)  // ��ġ �ΰ��� ��ġ�� �����Ǿ��� ���
        {
            return;
        }
        Touch firstTouch = Input.GetTouch(0);   //ù��° ��ġ ����
        Touch secondTouch = Input.GetTouch(1);  // �ι�°

        // ���� ��ġ- ��ġ ��ȭ���� ����Ͽ� ���� �������� ��ġ ��ġ�� ����
        Vector2 firstTouchPPosition = firstTouch.position - firstTouch.deltaPosition;
        Vector2 secondTouchPPosition = secondTouch.position - secondTouch.deltaPosition;

        // ���� �ΰ��� ��ġ ������ �Ÿ�
        float PastpositionDistance = (firstTouchPPosition - secondTouchPPosition).magnitude;
        // ���� �ΰ��� ��ġ ������ �Ÿ�
        float CurpostionDistance = (firstTouch.position - secondTouch.position).magnitude;

        //�� ��ġ �� -> ��ŭ�� ����/�ƿ��� �� �� ����
        float ZoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomSpeed;

        // ���� �������� �� ��ġ ������ �Ÿ��� ���纸�� ���� ��� -> �� ��
        if (PastpositionDistance < CurpostionDistance)
        {
            cameraTransform.position += Vector3.back * ZoomModifier * Time.deltaTime;

        }

        // ���� �������� �� ��ġ ������ �Ÿ��� ���纸�� Ŭ ��� -> �� �ƿ�
        else if (PastpositionDistance > CurpostionDistance)
        {
            cameraTransform.position += Vector3.forward * ZoomModifier * Time.deltaTime;

        }
    }


}
