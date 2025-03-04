using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ChatBot_Test : MonoBehaviour
{
    // OpenAI API 키와 사용할 모델 설정
    private string apiKey = "YOUR_OPENAI_API_KEY"; // OpenAI API 키를 입력
    private string model = "gpt-4"; // 사용할 모델 이름 설정

    // UI 요소 참조
    public InputField userInput;  // 사용자 입력 필드
    public Button sendButton;     // 전송 버튼
    public Text responseText;     // 응답 표시 텍스트

    void Start(){
        // 버튼 클릭 이벤트 등록
        sendButton.onClick.AddListener(OnSendButtonClicked);
    }

    // 버튼 클릭 시 OpenAI로 메시지를 전송
    void OnSendButtonClicked(){
        string message = userInput.text;
        if (!string.IsNullOrEmpty(message)){
            responseText.text = "Thinking...";
            SendMessageToOpenAI(message);
        }
    }

    // 사용자의 메시지를 OpenAI로 전송하는 함수
    public void SendMessageToOpenAI(string message){
        // UnityWebRequest를 사용하여 HTTP 요청을 생성하고 OpenAI API로 전송
        StartCoroutine(SendRequest(message));
    }

    // HTTP 요청을 보내고 응답을 받는 코루틴
    private IEnumerator SendRequest(string message){
        // OpenAI API URL 설정
        string url = "https://api.openai.com/v1/chat/completions";

        // JSON 형식의 바디 생성
        string jsonBody = "{";
        jsonBody += "\"model\": \"" + model + "\",";
        jsonBody += "\"messages\": [{\"role\": \"user\", \"content\": \"" + message + "\"}]}";

        // UnityWebRequest로 POST 요청 설정
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        // API 인증 헤더 설정
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        // 요청을 보내고 응답을 기다림
        yield return request.SendWebRequest();

        // 요청 성공 여부 확인
        if (request.result == UnityWebRequest.Result.Success){
            // 응답 내용 처리 (JSON 응답 파싱)
            string responseText = request.downloadHandler.text;
            Debug.Log("ChatBot Response: " + responseText);

            // JSON 응답에서 필요한 데이터 추출 (예: Assistant의 응답)
            string assistantResponse = ExtractAssistantResponse(responseText);

            // 응답 처리 (예: UI에 표시하거나 콘솔에 출력)
            Debug.Log("Assistant: " + assistantResponse);
        }
        else{
            // 요청 실패 시 오류 처리
            Debug.LogError("Request failed: " + request.error);
        }
    }

    // 응답에서 Assistant의 메시지를 추출하는 함수
    private string ExtractAssistantResponse(string jsonResponse){
        // JSON에서 'choices' 배열과 그 안의 'message' 필드를 추출하여 Assistant의 응답을 가져옴
        int startIndex = jsonResponse.IndexOf("\"content\":") + 11;
        int endIndex = jsonResponse.IndexOf("\"", startIndex);
        return jsonResponse.Substring(startIndex, endIndex - startIndex);
    }
}
