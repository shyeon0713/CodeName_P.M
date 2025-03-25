using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;  //AudioMixer

public class SFXSlider : MonoBehaviour
{
    public Slider sfxslider;
    public float volume;

    public AudioMixer SfxControl;

    public void Awake()
    {
        sfxslider.value = 0.5f;  // volume UI 초기 설정 -> 50정도 
        SfxControl.SetFloat("sfxvolume", Mathf.Log10(sfxslider.value) * 20); // volume -> 50으로

        sfxslider.onValueChanged.AddListener(SetBGMVolume);
    }

    private void SetBGMVolume(float Slidervalue)    //Slider UI
    {
        SfxControl.SetFloat("sfxvolume", Mathf.Log10(Slidervalue) * 20);
        // Volume 값이 데시벨이기 때문에 고정적인 간격을 가지지 못함으로 Log10 사용
    }
}
