using UnityEngine;
using UnityEngine.SceneManagement;  // �� ���� ��� ���

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
    public bool isPlaying = true;

    [System.Serializable]
    public struct SceneBGM
    {
        public string sceneName;
        public AudioClip bgmClip;
    }

    public SceneBGM[] BGMList;

    private void Awake()
    {
        // �̱��� ���� ���� (�ߺ� ���� ����)
        if (FindObjectsOfType<SoundManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        BGM = gameObject.AddComponent<AudioSource>();

        // ���� �ٲ� ������ BGM ����
        SceneManager.sceneLoaded += OnSceneLoaded;

        // ���� ���� BGM ����
        SetBGM(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetBGM(scene.name);
    }

    public void SetBGM(string sceneName)
    {
        for (int i = 0; i < BGMList.Length; i++)
        {
            if (BGMList[i].sceneName == sceneName)
            {
                if (BGM.clip != BGMList[i].bgmClip)  // ���� ���̸� ���� X
                {
                    BGM.clip = BGMList[i].bgmClip;
                    if (isPlaying)
                    {
                        BGM.Play();
                    }
                }
                return;
            }
        }
      
    }

    public void PlayMusic()
    {
        if (isPlaying)
            BGM.Pause();
        else
            BGM.Play();

        isPlaying = !isPlaying;
    }
}
