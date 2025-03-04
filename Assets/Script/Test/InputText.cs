using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  //TextPro 사용


public class InputText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    [SerializeField]
    private TMP_InputField inputField;  //InputField를 코드에서 생성할 시, 메서드 리스트 사용 가능


    //(+) InputField 컴포넌트는 UnityEngine.UI.InputField / TextMeshPro - InputField 컴포넌트는 TMPro.TMP_InputField

    private void Awake()
    {  //InpoutField의 이벤트 메소드들은 string 매개변수 1개를 가지고 있어야 함
        inputField.onValueChanged.AddListener(OnValueChangedEvent);
        inputField.onEndEdit.AddListener(OnEndEditEvent);
        inputField.onSelect.AddListener(OnSelectevent);
        inputField.onDeselect.AddListener(OnDeselectEvent);

    }
    public void OnValueChangedEvent(string TestText)  //InputField의 데이터가 바뀔 때 호출
    {
        Text.text = $"Value Changed : {TestText}";
    }

    public void OnEndEditEvent(string TestText)  //InputField의 데이터를 입력하고 Enter를 누를 때 호출
    {
        Text.text = $"End Edit : {TestText}";
    }

    public void OnSelectevent(string TestText)  //InputField가 활성화 되었을 때 호출
    {
        Text.text = $"Select : {TestText}";
    }

    public void OnDeselectEvent(string TestText)   //InputField가 비활성화 되었을 때 호출
    {
        Text.text = $"Deselect : {TestText}";
    }
}
