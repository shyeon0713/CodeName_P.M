using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;   //AudioMixer

public class SoundSlider : MonoBehaviour
{
    public Slider bgmslider;
    public float volume;

    public AudioMixer SoundControl; // ������ ����� �ͼ�

  // private SoundManager soundManager;

    // Update is called once per frame
    public void Awake()
    {
        bgmslider.value = 0.5f;  // volume UI �ʱ� ���� -> 50���� 
        SoundControl.SetFloat("bgmvolume", Mathf.Log10(bgmslider.value) * 20); // volume -> 50����

        bgmslider.onValueChanged.AddListener(SetBGMVolume);
    }

    private void SetBGMVolume(float Slidervalue)    //Slider UI
    {
        SoundControl.SetFloat("bgmvolume", Mathf.Log10(Slidervalue) * 20);
        // Volume ���� ���ú��̱� ������ �������� ������ ������ �������� Log10 ���
    }
}
