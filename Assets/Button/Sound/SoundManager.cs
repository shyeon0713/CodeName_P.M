using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
    public bool OnSound = true;

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
                    if (OnSound)
                    {
                        BGM.Play();
                    }
                }
                return;
            }
        }
      
    }

    public void PlaySound()
    {
        if (OnSound)
            BGM.Pause();
        else
            BGM.Play();

        OnSound = !OnSound;
    }
}
