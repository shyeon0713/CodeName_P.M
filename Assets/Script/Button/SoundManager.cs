using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;  // ����� �ҽ�
    public bool isPlaying = true;  // ���� ��� ����(ó������ ���)

    [System.Serializable]
    public struct SceneBGM
    {
        public string sceneName;  // �� �̸� 
        public AudioClip bgmClip;  // �ش� ���� ���� �������
    }

    public SceneBGM[] BGMList;

    private void Awake()
    {
        // BGM ����� �ҽ� �ʱ�ȭ
        BGM = gameObject.AddComponent<AudioSource>();

        // �� ��ȯ �� ���� ���� ����
        DontDestroyOnLoad(gameObject);

        // BGM�� �̹� ��� ���̸� ��� ���� ����
        if (isPlaying)
        {
            BGM.Play();
        }
        else
        {
            BGM.Pause();
        }
    }

    // ���� ���/�Ͻ� ���� ó��
    public void PlayMusic()
    {
        if (isPlaying)
        {
            BGM.Pause();  // ���� �Ͻ� ����
        }
        else
        {
            BGM.Play();  // ���� ���
        }

        isPlaying = !isPlaying;  // ���� ����
    }

    // ���� �´� ������� ����
    public void SetBGM(AudioClip bgmClip)
    {
        BGM.clip = bgmClip;
        if (isPlaying)
        {
            BGM.Play();
        }
    }
}

