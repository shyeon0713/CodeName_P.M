using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;   //AudioMixer

public class SoundSlider : MonoBehaviour
{
    public Slider bgmslider;
    public AudioMixer SoundControl; // 만들어둔 오디오 믹서

  // private SoundManager soundManager;

    // Update is called once per frame
    public void Awake()
    {

        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);  // 저장된 볼륨값 불러오기 (없으면 0.5f)

        bgmslider.value = savedVolume;
        SetBGMVolume(savedVolume);  // 초기 오디오 볼륨도 설정

        bgmslider.onValueChanged.AddListener(SetBGMVolume);
    }

    private void SetBGMVolume(float slidervalue)    //Slider UI
    { // 데시벨 변환 후 오디오 믹서에 적용
        SoundControl.SetFloat("bgmvolume", Mathf.Log10(slidervalue) * 20);
        // Volume 값이 데시벨이기 때문에 고정적인 간격을 가지지 못함으로 Log10 사용

        // 저장
        PlayerPrefs.SetFloat("BGMVolume", slidervalue);
        PlayerPrefs.Save();
    }
}
