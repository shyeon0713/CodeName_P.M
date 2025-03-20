using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;  // 오디오 소스
    public bool isPlaying = true;  // 음악 재생 상태(처음에는 재생)

    [System.Serializable]
    public struct SceneBGM
    {
        public string sceneName;  // 씬 이름 
        public AudioClip bgmClip;  // 해당 씬에 대한 배경음악
    }

    public SceneBGM[] BGMList;

    private void Awake()
    {
        // BGM 오디오 소스 초기화
        BGM = gameObject.AddComponent<AudioSource>();

        // 씬 전환 시 음악 상태 유지
        DontDestroyOnLoad(gameObject);

        // BGM이 이미 재생 중이면 재생 상태 유지
        if (isPlaying)
        {
            BGM.Play();
        }
        else
        {
            BGM.Pause();
        }
    }

    // 음악 재생/일시 정지 처리
    public void PlayMusic()
    {
        if (isPlaying)
        {
            BGM.Pause();  // 음악 일시 정지
        }
        else
        {
            BGM.Play();  // 음악 재생
        }

        isPlaying = !isPlaying;  // 상태 반전
    }

    // 씬에 맞는 배경음악 설정
    public void SetBGM(AudioClip bgmClip)
    {
        BGM.clip = bgmClip;
        if (isPlaying)
        {
            BGM.Play();
        }
    }
}

