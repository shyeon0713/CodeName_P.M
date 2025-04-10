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
        sfxslider.value = 0.5f;  // volume UI �ʱ� ���� -> 50���� 
        SfxControl.SetFloat("sfxvolume", Mathf.Log10(sfxslider.value) * 20); // volume -> 50����

        sfxslider.onValueChanged.AddListener(SetBGMVolume);
    }

    private void SetBGMVolume(float Slidervalue)    //Slider UI
    {
        SfxControl.SetFloat("sfxvolume", Mathf.Log10(Slidervalue) * 20);
        // Volume ���� ���ú��̱� ������ �������� ������ ������ �������� Log10 ���
    }
}
