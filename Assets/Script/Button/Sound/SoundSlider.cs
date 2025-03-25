using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;   //AudioMixer

public class SoundSlider : MonoBehaviour
{
    public Slider bgmslider;
    public float volume;

    public AudioMixer SoundControl; // 만들어둔 오디오 믹서

  // private SoundManager soundManager;

    // Update is called once per frame
    public void Awake()
    {
        bgmslider.value = 0.5f;  // volume UI 초기 설정 -> 50정도 
        SoundControl.SetFloat("bgmvolume", Mathf.Log10(bgmslider.value) * 20); // volume -> 50으로

        bgmslider.onValueChanged.AddListener(SetBGMVolume);
    }

    private void SetBGMVolume(float Slidervalue)    //Slider UI
    {
        SoundControl.SetFloat("bgmvolume", Mathf.Log10(Slidervalue) * 20);
        // Volume 값이 데시벨이기 때문에 고정적인 간격을 가지지 못함으로 Log10 사용
    }
}
