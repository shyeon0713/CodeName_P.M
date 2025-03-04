using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  //TextPro ���


public class InputText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    [SerializeField]
    private TMP_InputField inputField;  //InputField�� �ڵ忡�� ������ ��, �޼��� ����Ʈ ��� ����


    //(+) InputField ������Ʈ�� UnityEngine.UI.InputField / TextMeshPro - InputField ������Ʈ�� TMPro.TMP_InputField

    private void Awake()
    {  //InpoutField�� �̺�Ʈ �޼ҵ���� string �Ű����� 1���� ������ �־�� ��
        inputField.onValueChanged.AddListener(OnValueChangedEvent);
        inputField.onEndEdit.AddListener(OnEndEditEvent);
        inputField.onSelect.AddListener(OnSelectevent);
        inputField.onDeselect.AddListener(OnDeselectEvent);

    }
    public void OnValueChangedEvent(string TestText)  //InputField�� �����Ͱ� �ٲ� �� ȣ��
    {
        Text.text = $"Value Changed : {TestText}";
    }

    public void OnEndEditEvent(string TestText)  //InputField�� �����͸� �Է��ϰ� Enter�� ���� �� ȣ��
    {
        Text.text = $"End Edit : {TestText}";
    }

    public void OnSelectevent(string TestText)  //InputField�� Ȱ��ȭ �Ǿ��� �� ȣ��
    {
        Text.text = $"Select : {TestText}";
    }

    public void OnDeselectEvent(string TestText)   //InputField�� ��Ȱ��ȭ �Ǿ��� �� ȣ��
    {
        Text.text = $"Deselect : {TestText}";
    }
}
