using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;  // AudioMixer 활용
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{ 
    // Sound를 관리하는 Manager 스크립트를 각자 제작하여 버튼을 누르거나 상호작용을 할 경우, 참조하여 활용
    public AudioSource SFX;  //사용처에 따라 버튼 이름 변경
    public bool OnSFX = true;

    [System.Serializable]
    public struct SceneSFX
    {
        public string SFXName;  //효과음 종류 작성
        public AudioClip bgmClip;
    }

    public SceneSFX[] SFXList;

    public AudioMixer SoundControl;
    float volume;  
    public Slider SFXslider;   //Slider 조절 -> SFXMananger에서 값 조절


    private void Awake()
    {
        SoundControl.GetFloat("sfxvolume", out volume);
        SFXslider.value = 0.3f;  // volume 값 초기 설정 -> 50정도

        SFXslider.onValueChanged.AddListener(SetSFXVolume); 

        // 싱글톤 패턴 적용 (중복 생성 방지)
        if (FindObjectsOfType<SFXManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        SFX = GetComponent<AudioSource>();  //SoundManager의 BGM부분 이유와 동일 -> GetComponent<AudioSource>()로 수정

        SetSFX(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoad (Scene scene, LoadSceneMode mode)
    {
        SetSFX(scene.name);
    }
  
    public void SetSFX(string SFXName)
    {
        for (int i= 0; i < SFXList.Length; i++)
        {
            if(SFXList[i].SFXName == SFXName)
            {

                if(SFX.clip != SFXList[i].bgmClip)  //같을 경우 변경 X
                {
                    SFX.clip = SFXList[i].bgmClip;
                    if (OnSFX)
                    {
                        SFX.Play(); 
                    }
                }


                return;
            }
        }

    }

    public void PlaySFX()
    {
        if (OnSFX)
            SFX.Pause();
        else
            SFX.Play();

        OnSFX = !OnSFX;
    }
    private void SetSFXVolume(float value)
    {
        SoundControl.SetFloat("sfxvolume", Mathf.Log10(value) * 20);
    }
}
