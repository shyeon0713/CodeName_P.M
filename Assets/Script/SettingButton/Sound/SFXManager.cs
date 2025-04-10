using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;  // AudioMixer 활용
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{
    // 싱글톤 인스턴스 
    public static SFXManager Instance { get; private set; }
    // Instance는 싱글톤 패턴에서 사용되는 정적변수를 의미
    //클래스의 하나의 인스턴스를 전역에서 참조할 수 있도록 만듬(참고)

    public AudioSource SFX;
    public bool OnSFX = true;

    [System.Serializable]
    public struct SceneSFX
    {
        public string SFXName;  // 효과음 이름
        public AudioClip SFXClip;
    }

    public SceneSFX[] SFXList;

   // public AudioMixer SoundControl;
  //  float volume;
   // public Slider SFXslider;  // UI Slider 연결

    private void Awake()
    {
        // 싱글톤 패턴 적용
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 씬 변경 시 유지
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // 오디오 소스 가져오기 (null 방지)
        // -> 기존의 방식의 경우, 씬이 전환되면서 간혹가다가 AudioSource가 Null상태가 되는 경우 발생
        // 따라서 null이 아닌 경우를 조건을 하여 AudioSource추가
        SFX = GetComponent<AudioSource>();
        if (SFX == null)
        {
            SFX = gameObject.AddComponent<AudioSource>();
        }

        /*
        // 오디오 믹서 초기 설정
        if (SoundControl != null)
        {
            SoundControl.GetFloat("sfxvolume", out volume);
            SFXslider.value = Mathf.Pow(10, volume / 20);  // UI 슬라이더 초기 값 설정
            SFXslider.onValueChanged.AddListener(SetSFXVolume);
        }
        */
    }

    public void PlaySFX(string SFXName)
    {
        for (int i = 0; i < SFXList.Length; i++)
        {
            if (SFXList[i].SFXName == SFXName)
            {
                SFX.PlayOneShot(SFXList[i].SFXClip);  // 효과음 한 번 재생
                return;
            }
        }
        Debug.LogWarning($"SFX '{SFXName}' not found!");
    }

    /*
    private void SetSFXVolume(float value)
    {
        SoundControl.SetFloat("sfxvolume", Mathf.Log10(value) * 20);
    }
    */



    //문제 -> Scene를 전환할 경우 이전 Scene에서 저장한 볼륨기록이 똑같이 적용되지 않음
    // 해결방안 -> Player.prefs를 만든 후, 설정 값 저장
    // Player.prefs의 경우 씬이 전환되면서 플레이어가 게임에 저장해야 할 부분을 저장
}
