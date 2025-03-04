using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ChatBot_Test : MonoBehaviour
{
    // OpenAI API Ű�� ����� �� ����
    private string apiKey = "YOUR_OPENAI_API_KEY"; // OpenAI API Ű�� �Է�
    private string model = "gpt-4"; // ����� �� �̸� ����

    // UI ��� ����
    public InputField userInput;  // ����� �Է� �ʵ�
    public Button sendButton;     // ���� ��ư
    public Text responseText;     // ���� ǥ�� �ؽ�Ʈ

    void Start(){
        // ��ư Ŭ�� �̺�Ʈ ���
        sendButton.onClick.AddListener(OnSendButtonClicked);
    }

    // ��ư Ŭ�� �� OpenAI�� �޽����� ����
    void OnSendButtonClicked(){
        string message = userInput.text;
        if (!string.IsNullOrEmpty(message)){
            responseText.text = "Thinking...";
            SendMessageToOpenAI(message);
        }
    }

    // ������� �޽����� OpenAI�� �����ϴ� �Լ�
    public void SendMessageToOpenAI(string message){
        // UnityWebRequest�� ����Ͽ� HTTP ��û�� �����ϰ� OpenAI API�� ����
        StartCoroutine(SendRequest(message));
    }

    // HTTP ��û�� ������ ������ �޴� �ڷ�ƾ
    private IEnumerator SendRequest(string message){
        // OpenAI API URL ����
        string url = "https://api.openai.com/v1/chat/completions";

        // JSON ������ �ٵ� ����
        string jsonBody = "{";
        jsonBody += "\"model\": \"" + model + "\",";
        jsonBody += "\"messages\": [{\"role\": \"user\", \"content\": \"" + message + "\"}]}";

        // UnityWebRequest�� POST ��û ����
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        // API ���� ��� ����
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        // ��û�� ������ ������ ��ٸ�
        yield return request.SendWebRequest();

        // ��û ���� ���� Ȯ��
        if (request.result == UnityWebRequest.Result.Success){
            // ���� ���� ó�� (JSON ���� �Ľ�)
            string responseText = request.downloadHandler.text;
            Debug.Log("ChatBot Response: " + responseText);

            // JSON ���信�� �ʿ��� ������ ���� (��: Assistant�� ����)
            string assistantResponse = ExtractAssistantResponse(responseText);

            // ���� ó�� (��: UI�� ǥ���ϰų� �ֿܼ� ���)
            Debug.Log("Assistant: " + assistantResponse);
        }
        else{
            // ��û ���� �� ���� ó��
            Debug.LogError("Request failed: " + request.error);
        }
    }

    // ���信�� Assistant�� �޽����� �����ϴ� �Լ�
    private string ExtractAssistantResponse(string jsonResponse){
        // JSON���� 'choices' �迭�� �� ���� 'message' �ʵ带 �����Ͽ� Assistant�� ������ ������
        int startIndex = jsonResponse.IndexOf("\"content\":") + 11;
        int endIndex = jsonResponse.IndexOf("\"", startIndex);
        return jsonResponse.Substring(startIndex, endIndex - startIndex);
    }
}
